using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOne : MonoBehaviour {
	public Rigidbody2D rigidBody;
	public float paddleSpeed;

	public KeyCode upButton;
	public KeyCode downButton;

	private Vector2 direction;

	// Update is called once per frame.
	public void Update() {
		if (Input.GetKey(upButton)) {
			direction = Vector2.up;
		} else if (Input.GetKey(downButton)) {
			direction = Vector2.down;
		} else {
			direction = Vector2.zero;
		}
	}

	private void FixedUpdate() {
		if (direction.y != 0) {
			rigidBody.AddForce(direction * paddleSpeed);
		}
	}
}
