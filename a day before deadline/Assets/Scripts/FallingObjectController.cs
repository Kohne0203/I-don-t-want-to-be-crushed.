using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    public float fallSpeed;
    public float waitTime;
    public Rigidbody rb;
    GameObject character;

    public GameManager gameManager;
    public VariableManager variable;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        variable = GameObject.Find("VariableManager").GetComponent<VariableManager>();
        character = GameObject.Find("unitychan");

        rb.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        waitTime = variable.WaitTime;
        Invoke("Fall", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.currentGameState == GameManager.GameState.MoveStage)
        {
            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        fallSpeed = variable.FallSpeed;
        rb.isKinematic = false;
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.GameOver();
        }
        else if (other.gameObject.tag == "Stage")
        {
            Destroy(gameObject);
            gameManager.surviveCount += 1;
        }
    }
}
