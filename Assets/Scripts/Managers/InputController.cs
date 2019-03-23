using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

	public bool gamePaused = true;
	public GameController GameController;
    private UIController UIController;
    UnitManager unitManager;
	public string pauseButton;
	public string speedUpButton;
	public string speedDownButton;
	public string debugUnpauseButton;
	public bool debugInput = false;

	void Start(){
		GameController = GameObject.Find ("GameController").GetComponent<GameController> ();
        UIController = GameObject.Find("UIController").GetComponent<UIController>();
        unitManager = WorldMethods.GetUnitManager();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (pauseButton)) {
            //GameController.UnPauseTicks();
            gamePaused = !gamePaused;
		}

		if (Input.GetKeyDown (speedUpButton)) {
			if (GameController.GameSpeed < 5) {
				int newSpeed = GameController.GameSpeed + 1;
				GameController.ChangeGameSpeed (newSpeed);
                UIController.UpdateCalendarDisplay();
            } 
			else {
				MonoBehaviour.print ("At max speed already");
			}
		}
		if (Input.GetKeyDown (speedDownButton)) {
			if (GameController.GameSpeed > 1) {
				int newSpeed = GameController.GameSpeed - 1;
				GameController.ChangeGameSpeed (newSpeed);
                UIController.UpdateCalendarDisplay();
            } 
			else {
				MonoBehaviour.print ("At slowest speed already");
			}
		}

		//Debug inputs
		if (debugInput){
			//Debug Unpause
			if (Input.GetKeyUp(debugUnpauseButton)){
                gamePaused = false;
				GameController.UnPauseTicks ();
			}	
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.GetKeyUp ("0")) {
			SceneManager.LoadScene ("StartupScene");
		}
	}
}
