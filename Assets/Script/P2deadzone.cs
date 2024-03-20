using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P2deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallController ball = collision.GetComponent<BallController>();
        if (collision.gameObject.tag == "P2ball")
            if (!ball.isexpand)
                SceneManager.LoadScene("P1 Win");
    }
}
