using UnityEngine;
using UnityEngine.SceneManagement;

public class P1deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallController ball = collision.GetComponent<BallController>();
        if (collision.gameObject.tag == "P1ball")
            if (!ball.isexpand)
                SceneManager.LoadScene("P2 Win");
    }
}