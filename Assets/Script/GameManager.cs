using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject P1ballPrefab; // P1ball �������� ������ ����
    public GameObject P2ballPrefab; // P2ball �������� ������ ����

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // P1ball �������� �����Ͽ� ���콺 Ŭ�� ��ġ�� ��ġ��ŵ�ϴ�.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z���� 0���� �����Ͽ� 2D ������ ��ġ�մϴ�.
            Instantiate(P1ballPrefab, mousePosition, Quaternion.identity);
        }

        // ���콺 ������ ��ư�� Ŭ������ ��
        if (Input.GetMouseButtonDown(1))
        {
            // P2ball �������� �����Ͽ� ���콺 Ŭ�� ��ġ�� ��ġ��ŵ�ϴ�.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z���� 0���� �����Ͽ� 2D ������ ��ġ�մϴ�.
            Instantiate(P2ballPrefab, mousePosition, Quaternion.identity);
        }
    }
}