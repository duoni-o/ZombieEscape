using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 앞(forward, z, blue arrow) 방향으로 이동하고 싶다.
// - 속력
// - 강체(Rigidbody)
// 무엇인가와 충돌하면 너죽고 나죽고 하고싶다.(단, 배경에 해당하는 녀석들은 건들지 말자)
public class Bullet : MonoBehaviour
{
    // - 속력
    public float speed = 10;
    // - 강체(Rigidbody)
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 1. 총알의 이동방향을 총알의 앞방향으로 등속도 운동을 하고싶다.
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 총알의 이동방향으로 회전하고싶다.
        transform.forward = rb.velocity.normalized;

    }

    private void OnCollisionEnter(Collision other)
    {
        // 1. 만약 배경이 아니라면
        if (other.gameObject.tag != "Land")
        {
            // 2. 너죽고
            Destroy(other.gameObject);
        }
        // 3. 나죽자
        Destroy(this.gameObject);
    }
}
