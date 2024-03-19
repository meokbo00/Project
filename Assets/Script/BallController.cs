using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    public float expand = 4f;
    private bool iscolliding = false;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * 300 * Time.deltaTime;
    }

    private void Update()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;

        if (rigid.velocity.magnitude < 0.01f && !iscolliding)
        {
            transform.localScale += Vector3.one * expand * Time.deltaTime;
            StartCoroutine(TurnCameraSmoothly());
        }
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        rigid.velocity = dir * Mathf.Max(lastVelocity.magnitude, 0f); // 감속하지 않고 반사만 진행
        this.iscolliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.iscolliding = false;
    }
    IEnumerator TurnCameraSmoothly()
    {

        float elapsedTime = 0f;
        float duration = 1f; // 회전 소요 시간

        Quaternion startRotation = Camera.main.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 180f); // 목표 회전 각도

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            Camera.main.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 회전 완료 후 최종 각도 설정
        Camera.main.transform.rotation = endRotation;
    }
}