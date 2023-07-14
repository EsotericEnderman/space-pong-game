using UnityEngine;
using Math = System.Math;

public class BounceOnSurface : MonoBehaviour {
	public float bounceStrength;

	private void OnCollisionEnter2D(Collision2D collision) {
		PongBall ball = collision.gameObject.GetComponent<PongBall>();

		// Prevents the script affecting the ball's velocity after it has been reset.
		if ((ball != null) && ((Math.Abs(ball.transform.position.x) < 7.449597f) || (Math.Abs(ball.transform.position.y) < 5.587201f))) {
			Vector2 normal = collision.GetContact(0).normal;

			ball.rigidBody.AddForce(-normal * bounceStrength);
		}
	}
}
