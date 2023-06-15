using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector2 inputVec;
    [SerializeField] float speed;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void LateUpdate()
    {
        //백터의 크기
        anim.SetFloat("Speed", inputVec.magnitude);

        //키 눌리면 1 아니면 0
        if (inputVec.x != 0){            
            sprite.flipX = inputVec.x < 0; //left : -1, right : +1
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

}
