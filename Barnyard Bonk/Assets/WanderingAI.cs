using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    public Animator duckAnimator;
    public AnimalCounter animalCount;

    private bool inPen;
    private bool isGrounded;

    void Start()
    {
        inPen = false;
    }

    void Update()
    {
        // patrolling/walking
        if (!inPen && isGrounded)
        {
            duckAnimator.SetBool("IsWalking", true);
            duckAnimator.SetBool("IsStunned", false);
            Debug.Log("IsWalking true, IsStunned False");
            duckAnimator.SetBool("IsIdle", false);
            duckAnimator.SetBool("IsJump", false);

            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }

        else if (!inPen && !isGrounded)
        {
            duckAnimator.SetBool("IsWalking", false);
            duckAnimator.SetBool("IsStunned", true);
            Debug.Log("set IsWalking to False & IsStunned to True ");

            duckAnimator.SetBool("IsIdle", false);
            duckAnimator.SetBool("IsJump", false);
        }

        else if (inPen && isGrounded)
        {
            duckAnimator.SetBool("IsWalking", false);
            duckAnimator.SetBool("IsStunned", false);
            duckAnimator.SetBool("IsIdle", true);
            duckAnimator.SetBool("IsJump", false);
        }

        else if (inPen && !isGrounded)
        {
            duckAnimator.SetBool("IsWalking", false);
            duckAnimator.SetBool("IsStunned", false);
            duckAnimator.SetBool("IsIdle", false);
            duckAnimator.SetBool("IsJump", true);
        }
    }

    //change the value of inPen from another script
    //public void SetInPen(bool isInPen)
    //{
        //inPen = isInPen;
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
            Debug.Log("Duck has touched floor");
        }

        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
            Debug.Log("Duck has touched floor");
        }

        if (collision.gameObject.name == "PenGround")
        {
            inPen = true;
            isGrounded = true;
            Debug.Log("Duck has touched pen floor");

            animalCount.counter++;
            animalCount.UpdateUICounter();
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
            Debug.Log("Duck is not touching floor");
        }

        if (collision.gameObject.name == "PenGround")
        {
            inPen = true;
            isGrounded = false;
            Debug.Log("Duck left the pen floor");
        }
    }
}
