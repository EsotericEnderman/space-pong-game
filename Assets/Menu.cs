using UnityEngine;

using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void SelectScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
