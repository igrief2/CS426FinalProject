using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void QuitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
	}

	public void PlayMultiplayer(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //assumes main scene is 2 scenes after main menu scene
	}

	public void PlayTutorial(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //gets next scene in scene queue
	}
}
	