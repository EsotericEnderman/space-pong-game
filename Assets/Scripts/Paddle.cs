using UnityEngine;

public class Paddle : MonoBehaviour {
	public Rigidbody2D rigidBody, ballRigidbody;
	public float paddleSpeed;

	public KeyCode upButton, downButton;

	private Vector2 direction;

	public bool isComputer;
	public SpriteRenderer spriteRenderer;

	public void Update() {
		if (!isComputer) {
			if (Input.GetKey(upButton))
			{
				direction = Vector2.up;
			}
			else if (Input.GetKey(downButton))
			{
				direction = Vector2.down;
			}
			else
			{
				direction = Vector2.zero;
			}
		}
	}

	private void FixedUpdate() {
		if (!isComputer && direction.y != 0) {
			rigidBody.AddForce(direction * paddleSpeed);
		}

		if (rigidBody.velocity.y > 0) {
			spriteRenderer.flipY = false;
		} else if (rigidBody.velocity.y < 0) {
			spriteRenderer.flipY = true;
		}

		if (isComputer) {
			if (transform.position.x >= 0 ? ballRigidbody.velocity.x >= 0 : ballRigidbody.velocity.x <= 0) {
				if (ballRigidbody.position.y > transform.position.y)
				{
					rigidBody.AddForce(Vector2.up * paddleSpeed);
				}
				else if (ballRigidbody.position.y < transform.position.y)
				{
					rigidBody.AddForce(Vector2.down * paddleSpeed);
				}
			}

			else {
				if (transform.position.y > 0.0f)
				{
					rigidBody.AddForce(Vector2.down * paddleSpeed);
				}
				else if (transform.position.y < 0.0f)
				{
					rigidBody.AddForce(Vector2.up * paddleSpeed);
				}
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		PongBall ball = collision.gameObject.GetComponent<PongBall>();

		if (ball != null && transform.localScale.x > 0.2f) {
			transform.localScale += new Vector3(0, -0.1f, 0);
		}
	}
}
