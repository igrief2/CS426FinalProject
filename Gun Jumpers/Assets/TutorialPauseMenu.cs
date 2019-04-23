using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPauseMenu : MonoBehaviour
{

	public GameObject pauseMenu;

	void Start(){
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}

	void Update(){
		if(Input.GetButtonDown("Cancel")){
			Debug.Log("cancel pressed, timescale = " + Time.timeScale);
			if(Time.timeScale == 1){
				Debug.Log("timescale set to 0, activate pause menu");
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
			}
			else if(Time.timeScale == 0){
				Debug.Log("timescale set to 1, deactivate pause menu");
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}

	public void ToMainMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //gets previous scene in scene queue
	}


}
