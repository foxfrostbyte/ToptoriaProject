using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    private bool isSpeedMultiplied = false;

    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if (
         Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
         Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
         {
          animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
          animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
         }

      if (Input.GetKeyDown("left shift") && !isSpeedMultiplied)
      { 
         speed *= 1.4f;
         isSpeedMultiplied = true;
      }

      else if (!Input.GetKeyUp("left shift") && isSpeedMultiplied)
        {
            // Reset the speed back to its original value
            speed /= 1.4f;
            isSpeedMultiplied = false;
        }
    }
    
    void FixedUpdate()
    {
      rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}