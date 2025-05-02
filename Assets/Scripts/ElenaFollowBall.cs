using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElenaFollowBall : MonoBehaviour
{
    public Transform ballTransform;
    public float speed;

    // Update is called once per frame
    void Update()
    {
         if (ballTransform != null)
        {
            Vector3 direction = ballTransform.position - transform.position;

            // Normalize the direction vector to ensure consistent movement speed.
            direction.Normalize();

            // Move Elena towards the ball based on the specified speed.
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
