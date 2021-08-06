using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;//Sprite 오브젝트 참조

    public bool IsDead()
    {
        return isDead;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>(); //Animator 컴포넌트 취득
    }

    // Update is called once per frame
    void Update()
    {
        // 최고 고도에 도달하지 않은 경우에나 탭의 입력을 받는다.
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }

        // 각도를 반영
        ApplyAngle();

        // angle이 수평 이상이라면 애니메이터의 flap플래그를 true로 한다.
        animator.SetBool("flap", angle >= 0.0f);
    }

    private void ApplyAngle()
    {
        float targetAngle;

        // 사망하면 항상 아래를 향한다.
        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg; //벡터로부터 각도 계산
        }

        // 회전 애니메이션을 스무딩
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        // Rotation의 반영
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    public void Flap()
    {
        // 죽으면 날아 오르지 않는다.
        if(isDead)
        {
            return;
        }

        // Velocity를 직접 바꿔 써서 위쪽 방향으로 가속
        rb2d.velocity = new Vector2(0.0f, flapVelocity);//속도 조작
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead)
        {
            return;
        }
        // 뭔가 부딪치면 사망 플래그를 true로 한다.
        isDead = true;
    }
}
