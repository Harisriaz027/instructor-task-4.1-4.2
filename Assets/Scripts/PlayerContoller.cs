using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRb;
    private float forwardInput;
    private float horizontalInput;
    public float speed = 10;
    public float turnSpeed=10;
    public GameObject pointer;
    public GameObject collided;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate( Vector3.forward*Time.deltaTime*speed*forwardInput);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 push = (collision.transform.position - transform.position)  ;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(push  * 12,ForceMode.Impulse);
        }
    }
}
