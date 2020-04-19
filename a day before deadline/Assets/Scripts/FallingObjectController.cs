using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float waitTime = 3;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        Invoke("Fall", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Fall()
    {
        rb.isKinematic = false;
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
