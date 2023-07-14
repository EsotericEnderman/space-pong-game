using UnityEngine;

using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour {
	public EventTrigger.TriggerEvent scoreTrigger;

	private void OnCollisionEnter2D(Collision2D collision) { 
		PongBall ball = collision.gameObject.GetComponent<PongBall>();

		if (ball != null) {
			BaseEventData eventData = new BaseEventData(EventSystem.current);

			scoreTrigger.Invoke(eventData);
		}
	}
}
