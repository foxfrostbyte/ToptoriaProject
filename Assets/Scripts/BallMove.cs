using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{   
  public Rigidbody2D rb;
  public Animator animator;
  public float velocity;
 
    void Update() {
      
      velocity =  rb.linearVelocity.magnitude;
    
      if (velocity > 0.15)
      { 
        animator.Play("Motion_Ball");
      }
     
      else if (velocity < 0.15)
      { 
        animator.Play("Idle_Ball");
      }
    }
}

