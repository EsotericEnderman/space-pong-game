using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public Rigidbody2D ballRigidBody;

    public float paddleSpeed;

    private void FixedUpdate() {
        if (ballRigidBody.velocity.x > 0) {
            if (ballRigidBody.position.y > transform.position.y) {
                rigidBody.AddForce(Vector2.up * paddleSpeed);
            } else if (ballRigidBody.position.y < transform.position.y) {
                rigidBody.AddForce(Vector2.down * paddleSpeed);
            }
        } else {
            if (transform.position.y > 0.0f) {
                rigidBody.AddForce(Vector2.down * paddleSpeed);
            } else if (transform.position.y < 0.0f) {
                rigidBody.AddForce(Vector2.up * paddleSpeed);
            }
        }
    }
}
