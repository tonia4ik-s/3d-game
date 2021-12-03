using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player speed")]
    public float speed = 7f;
    
    public float runSpeed = 15f;

    public float jumpPower = 200f;
    
    public Rigidbody rb;
    
    private bool _isOnTheGround;
    private int _jumpsCounter;
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
            if (_isOnTheGround)
            {
                _jumpsCounter = 0;
            }

            if (_jumpsCounter < 2)
            {
                rb.AddForce(transform.up * jumpPower);
                _jumpsCounter++;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Ground"))
        {
            _isOnTheGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag($"Ground"))
        {
            _isOnTheGround = false;
        }
    }
}
