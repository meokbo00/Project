using System.Collections;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    public float increase = 4f;
    private bool iscolliding = false;
    public bool hasExpanded = false;
    private bool isStopped = false;
    private int randomNumber;
    private TextMeshPro textMesh; // TextMeshPro 변수 추가

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * 300 * Time.deltaTime;

        GameObject textObject = new GameObject("TextMeshPro");
        textObject.transform.parent = transform; // 구체의 자식으로 설정
        textMesh = textObject.AddComponent<TextMeshPro>();
        randomNumber = Random.Range(1, 6);
        textMesh.text = randomNumber.ToString();
        textMesh.fontSize = 4;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.autoSizeTextContainer = true;
        textMesh.rectTransform.localPosition = Vector3.zero; // 구체 중심에 텍스트 배치
        textMesh.sortingOrder = 1; // 레이어 순서를 조정하여 구체 위에 배치
    }

    private void Update()
    {
        Move();
        expand();
    }

    void Move()
    {
        if (rigid == null || isStopped) return;

        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;

        if (rigid.velocity.magnitude <= 0.01f && hasExpanded)
        {
            isStopped = true;
            StartCoroutine(DestroyRigidbodyDelayed());
        }
    }

    void expand()
    {
        if (rigid == null || iscolliding) return;
        if (rigid.velocity.magnitude > 0.01f) return;
        transform.localScale += Vector3.one * increase * Time.deltaTime;
        hasExpanded = true;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "P1ball" || coll.gameObject.tag == "P2ball")
        {
            if (randomNumber > 0)
            {
                randomNumber--;
                textMesh.text = randomNumber.ToString();
            }
            if (randomNumber <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (coll.contacts != null && coll.contacts.Length > 0)
        {
            // 충돌 지점 정보가 있을 때만 처리
            Vector2 dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            if (rigid != null)
                rigid.velocity = dir * Mathf.Max(lastVelocity.magnitude, 0f); // 감속하지 않고 반사만 진행
        }
        this.iscolliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.iscolliding = false;
    }

    IEnumerator DestroyRigidbodyDelayed()
    {
        yield return new WaitForSeconds(0.8f);
        if (rigid != null)
            Destroy(rigid);
    }
}