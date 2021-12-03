using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player speed")]
    public float speed = 7f;
    
    public float runSpeed = 15f;

    public float jumpPower = 200f;

    public bool isOnTheGround;

    public Rigidbody rb;
    
    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        var transform1 = transform;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform1.localPosition += transform1.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform1.localPosition += transform1.forward * speed * Time.deltaTime;
            }
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform1.localPosition += -transform1.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform1.localPosition += -transform1.forward * speed * Time.deltaTime;
            }
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform1.localPosition += -transform1.right * runSpeed * Time.deltaTime;            
            }
            else
            {
                transform1.localPosition += -transform1.right * speed * Time.deltaTime;            
            }
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform1.localPosition += transform1.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform1.localPosition += transform1.right * speed * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnTheGround)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Ground"))
        {
            isOnTheGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag($"Ground"))
        {
            isOnTheGround = false;
        }
    }
}
