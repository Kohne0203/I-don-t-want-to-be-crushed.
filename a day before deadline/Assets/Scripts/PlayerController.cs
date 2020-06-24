using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineTrace;

public class PlayerController : MonoBehaviour
{
    //　Playerの挙動に関するスクリプト

    public DirectionController2d controller;
    public VariableManager variable;
    private Animator animator;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = variable.PlayerSpeed;

        // 方向キーの移動設定
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            controller.direction = Direction.back;
            transform.position += controller.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            controller.direction = Direction.front;
            transform.position += controller.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        animator.SetBool("Jumping", false);
    }

}
