using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject P1ballPrefab; 
    public GameObject P2ballPrefab; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z축을 0으로 설정하여 2D 공간에 배치합니다.
            Instantiate(P1ballPrefab, mousePosition, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z축을 0으로 설정하여 2D 공간에 배치합니다.
            Instantiate(P2ballPrefab, mousePosition, Quaternion.identity);
        }
    }
}