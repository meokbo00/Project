using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 lastVelocity;
    float deceleration = 2f;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * 300 * Time.deltaTime;
    }

    private void Update()
    {
        Move();
        if (rigid.velocity.magnitude < 0.01f)
        {
            //rigid.isKinematic = true;
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }
    void Move()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity -= rigid.velocity.normalized * deceleration * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        rigid.velocity = dir * Mathf.Max(lastVelocity.magnitude, 0f); // 감속하지 않고 반사만 진행
    }
}
