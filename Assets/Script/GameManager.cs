using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject P1ballPrefab;
    public GameObject P1firezone;
    private Vector3 clickPosition;
    private bool isDragging = false;

    // ���� ���� ����
    public static float shotDistance;
    public static Vector3 shotDirection;

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f;

            Collider2D[] colliders = Physics2D.OverlapPointAll(clickPosition);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == P1firezone)
                {
                    Instantiate(P1ballPrefab, clickPosition, Quaternion.identity);
                    isDragging = true;
                    break;
                }
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            GameManager.shotDistance = Vector3.Distance(clickPosition, currentPosition); // ���� ������ �� ����

            Vector3 dragDirection = (currentPosition - clickPosition).normalized;
            GameManager.shotDirection = -dragDirection; // ���� ������ �� ����

            isDragging = false;
        }
    }
}