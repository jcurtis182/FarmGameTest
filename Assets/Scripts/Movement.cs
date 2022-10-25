using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //move speed
    public float speed = 5;
    public Animator animator;

    private Vector3 direction;
    

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");              // get player input
        float vertical = Input.GetAxisRaw("Vertical");                  

        direction = new Vector2(horizontal, vertical);          // create normalized vector of the direction

        AnimateMovement(direction);
    }

    void FixedUpdate()              //To stop the "jitter' when running into walls, we want to delay movement until after collision is determined, so we run movement in a delayed update 
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

        }
    }
}
