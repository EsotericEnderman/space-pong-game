using UnityEngine;

using Random = System.Random;
using Math = System.Math;

public class PongBall : MonoBehaviour {

	public Rigidbody2D rigidBody;

	public int ballSpeed;

	// Range of angles = [-60, -30] u [30, 60].
	public double maxAngleDegrees;
	public double minAngleDegrees;

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

		rigidBody.position = Vector2.zero;
		rigidBody.velocity = Vector2.zero;

		rigidBody.AddForce(startingDirection * ballSpeed);
	}

	public void ResetPosition(int horizontalDirection = 0) {
		StartingForce(horizontalDirection);
	}
}
