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
            mousePosition.z = 0f; // z���� 0���� �����Ͽ� 2D ������ ��ġ�մϴ�.
            Instantiate(ballPrefab, mousePosition, Quaternion.identity);
        }
    }
}