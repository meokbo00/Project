using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject P1ballPrefab;
    public GameObject P1firezone;
    private Vector3 clickPosition;
    private bool isDragging = false;

<<<<<<< HEAD
    // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    public static float shotDistance;
    public static Vector3 shotDirection;

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }
=======
    // Àü¿ª º¯¼ö ¼±¾ð
    public static float shotDistance;
    public static Vector3 shotDirection;

>>>>>>> a606e8e4950a2e6d9860962abaec6bd22e9c7868
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
<<<<<<< HEAD
            GameManager.shotDistance = Vector3.Distance(clickPosition, currentPosition); // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½

            Vector3 dragDirection = (currentPosition - clickPosition).normalized;
            GameManager.shotDirection = -dragDirection; // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
=======
            GameManager.shotDistance = Vector3.Distance(clickPosition, currentPosition); // Àü¿ª º¯¼ö¿¡ °ª ¼³Á¤

            Vector3 dragDirection = (currentPosition - clickPosition).normalized;
            GameManager.shotDirection = -dragDirection; // Àü¿ª º¯¼ö¿¡ °ª ¼³Á¤
>>>>>>> a606e8e4950a2e6d9860962abaec6bd22e9c7868

            isDragging = false;
        }
    }
}