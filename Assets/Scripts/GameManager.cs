using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
	public PongBall pongBall;

	private int playerOneScore, playerTwoScore;
	public Paddle paddleOne, paddleTwo;

	public TMP_Text scoreText;

	public KeyCode resetButton;

	private void Start()
	{
		UpdateText();
	}

    private void Update()
    {
		if (Input.GetKeyDown(resetButton)) {
			ResetGame();
        } else if (Input.GetKeyUp("escape")) {
			Application.Quit();
        }
	}

    private void UpdateText() {
		scoreText.text = (paddleOne.isComputer ? paddleTwo.isComputer ? "Computer 1" : "Computer" : !paddleTwo.isComputer ? "Player 1" : "Player") + " - " + playerOneScore.ToString() + " | " + playerTwoScore.ToString() + " - " + (paddleTwo.isComputer ? paddleOne.isComputer ? "Computer 2" : "Computer" : !paddleOne.isComputer ? "Player 2" : "Player");
	}

	public void playerOneScores() {
		playerOneScore++;

		pongBall.ResetPosition(-1);

		UpdateText();
		paddleOne.gameObject.transform.localScale = new Vector3(1, 1, 1);
		paddleTwo.gameObject.transform.localScale = new Vector3(1, 1, 1);
	}

	public void playerTwoScores() {
		playerTwoScore++;

		pongBall.ResetPosition(1);

		UpdateText();
		paddleOne.gameObject.transform.localScale = new Vector3(1, 1, 1);
		paddleTwo.gameObject.transform.localScale = new Vector3(1, 1, 1);
	}

	private void ResetGame() {
		pongBall.ResetPosition();

		playerOneScore = 0;
		playerTwoScore = 0;

		UpdateText();
	}
}
