using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMG : MonoBehaviour
{
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z축을 0으로 설정하여 2D 공간에 배치합니다.
            Instantiate(ballPrefab, mousePosition, Quaternion.identity);
        }
    }
}