using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineTrace;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float xRange = 7.0f;
    public DirectionController2d controller;

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
    void Update()
    {

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        Vector3 posDiff = transform.position - playerPos;
        if (posDiff.magnitude != 0)
        {
            Debug.Log(posDiff);
        }

        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);

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

    private void OnTriggerEnter(Collider other)
    {
    
    }

    private void OnCollisionStay(Collision collision)
    {
        animator.SetBool("Jumping", false);
    }

}
