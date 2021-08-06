using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 최고 고도에 도달하지 않은 경우에나 탭의 입력을 받는다.
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }
    }

    public void Flap()
    {
        // Velocity를 직접 바꿔 써서 위쪽 방향으로 가속
        rb2d.velocity = new Vector2(0.0f, flapVelocity);//속도 조작
    }
}
