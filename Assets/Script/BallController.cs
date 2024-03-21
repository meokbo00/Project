using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    public float increase = 4f;
    private bool iscolliding = false;
    public bool hasExpanded = false;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * 300 * Time.deltaTime;
    }

    private void Update()
    {
        Move();
        if(CheckCondition())
        {
            expand();
        }
    }
    bool CheckCondition()
    {
        if (iscolliding || rigid.velocity.magnitude > 0.01f)
        {
            return false;
        }
        else if (iscolliding && rigid.velocity.magnitude > 0.01f)
        {
            return false;
        }
        else
            return true;
    }
    void Move()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;
    }
    void expand()
    {
        
        transform.localScale += Vector3.one * increase * Time.deltaTime;
        hasExpanded = true;
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
}