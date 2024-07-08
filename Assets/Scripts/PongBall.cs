using UnityEngine;

using Random = System.Random;
using Math = System.Math;

public class PongBall : MonoBehaviour {
	public Rigidbody2D rigidBody;
	// Used in the old collision speed increase script.
	// private Vector2 direction;

	public int ballSpeed;

	// // Range of angles = [-60, -30] u [30, 60].
	public double maxAngleDegrees;
	public double minAngleDegrees;

	// Start is called before the first frame update.
	public void Start() {
		StartingForce();
	}

	private void StartingForce(int horizontalDirection = 0) {
		Random random = new Random();

		if (horizontalDirection == 0) {
			horizontalDirection = (random.NextDouble() > 0.5f) ? 1 : -1;
		}

		// Angle to make ball go to corner = 36.8698976 degrees.

		float maxAngleTan = (float)Math.Tan(Mathf.Deg2Rad * maxAngleDegrees);
		float minAngleTan = (float)Math.Tan(Mathf.Deg2Rad * minAngleDegrees);

		Vector2 startingDirection = new Vector2(

			horizontalDirection,

			(random.NextDouble() > 0.5f ? 1 : -1)

			*

			(

			(float)random.NextDouble()

			*

			(
				maxAngleTan
				- minAngleTan
			)
				+ minAngleTan
			)
		);

		startingDirection.Normalize();

		// Used in the old collision speed increase script.
		// direction = startingDirection;

		rigidBody.position = Vector2.zero;
		rigidBody.velocity = Vector2.zero;

		rigidBody.AddForce(startingDirection * ballSpeed);
	}

	// Old collision speed increase script.

	// private void OnCollisionEnter2D() {
	//	if (Math.Abs(rigidBody.velocity.x) < 10 && Math.Abs(rigidBody.velocity.y) < 10) {
	// rigidBody.AddForce(direction * ballSpeed / 4);
	// direction *= -1;
	// }
	// 
	// Debug.Log(rigidBody.velocity);
	// Debug.Log(rigidBody.velocity.x);
	// Debug.Log(rigidBody.velocity.y);
	// }

	public void ResetPosition(int horizontalDirection = 0) {
		StartingForce(horizontalDirection);
	}
}
