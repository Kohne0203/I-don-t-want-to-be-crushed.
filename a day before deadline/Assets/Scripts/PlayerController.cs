using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineTrace;

public class PlayerController : MonoBehaviour
{
    float speed;
    public float horizontalInput;
    public float xRange = 7.0f;
    public DirectionController2d controller;
    public VariableManager variable;

    private Animator animator;
    private Vector3 playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerPos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
        animator.SetBool("Running", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = variable.PlayerSpeed;

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

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

    // 落下オブジェクトに当たったら
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        animator.SetBool("Jumping", false);
    }

}
