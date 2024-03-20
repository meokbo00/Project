using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject P1ballPrefab; // P1ball 프리팹을 연결할 변수
    public GameObject P2ballPrefab; // P2ball 프리팹을 연결할 변수

    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // P1ball 프리팹을 생성하여 마우스 클릭 위치에 위치시킵니다.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z축을 0으로 설정하여 2D 공간에 배치합니다.
            Instantiate(P1ballPrefab, mousePosition, Quaternion.identity);
        }

        // 마우스 오른쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(1))
        {
            // P2ball 프리팹을 생성하여 마우스 클릭 위치에 위치시킵니다.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z축을 0으로 설정하여 2D 공간에 배치합니다.
            Instantiate(P2ballPrefab, mousePosition, Quaternion.identity);
        }
    }
}