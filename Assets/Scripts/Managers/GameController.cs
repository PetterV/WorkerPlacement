using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int DaysProgressed = 0;
	public int WeekCount = 1;
	public int TotalWeekCount = 1;
	public System.Random GameRandom;
	public Date RealDate;
	public bool GameplayTickPause = false; //Use this for debug purposes or layered time-systems, otherwise use the InputController's gamePaused
	public UIController UIController;

	public bool TimeForTick;
	public int GameSpeed = 3;
	private float waitPerTickSpeedOne = 2f;
	private float waitPerTickSpeedTwo = 1f;
	private float waitPerTickSpeedThree = 0.5f;
	private float waitPerTickSpeedFour = 0.25f;
	private float waitPerTickSpeedFive = 0.1f;
	private float waitPerTick; //Seconds to wait per tick
	public float timeWaitedForTick;

	private InputController InputController;
    private PlayerResourceManager playerResourceManager;
    public SeasonManager seasonManager;

    //Resource Locations
    public GameObject[] allLocations;

    public float realUnitSpeedFactor = 0.005f;

	void Start(){
        InputController = WorldMethods.GetInputController();
        UIController = WorldMethods.GetUIController();
        playerResourceManager = WorldMethods.GetPlayerResourceManager();
        seasonManager = WorldMethods.GetSeasonManager();
        waitPerTick = waitPerTickSpeedThree; //Set the game speed to default
        UIController.UIControllerSetup();

        SetUpGame ();
	}

	void Update(){
		if (InputController.gamePaused == false && TimeForTick == true && GameplayTickPause == false) {
			WorldMethods.DailyTick ();
			TimeForTick = false;
		}
		if (TimeForTick == false) {
			timeWaitedForTick += Time.deltaTime;
			if (timeWaitedForTick > waitPerTick) {
				TimeForTick = true;
				timeWaitedForTick = 0;
			}
		}
	}

	void SetUpGame()
	{
        //Set up Random and Date
		GameRandom = new System.Random();
		RealDate = new Date();

        //Give Date starting values
		RealDate.Day = 1;
		RealDate.Month = 1;
		RealDate.Year = 1;

        //Generating the world will be done here
        WorldMethods.SetUpWorld();

        //Find all Locations
        allLocations = GameObject.FindGameObjectsWithTag("Location");

        //Set the correct connections and starting resource values
        playerResourceManager.SetUpResources();

        seasonManager.SetUpSeasons();

        UIController.UpdateCalendarDisplay();
        UIController.UpdateResourceDisplay();
    }

	public void ChangeGameSpeed(int newSpeed){
		switch (newSpeed) {
		case 1:
			waitPerTick = waitPerTickSpeedOne;
			GameSpeed = 1;
			break;
		case 2:
			waitPerTick = waitPerTickSpeedTwo;
			GameSpeed = 2;
			break;
		case 3:
			waitPerTick = waitPerTickSpeedThree;
			GameSpeed = 3;
			break;
		case 4:
			waitPerTick = waitPerTickSpeedFour;
			GameSpeed = 4;
			break;
		case 5:
			waitPerTick = waitPerTickSpeedFive;
			GameSpeed = 5;
			break;
		}
	}

	public void PauseTicks(){
		GameplayTickPause = true;
	}


	public void UnPauseTicks(){
		GameplayTickPause = false;
	}
}
