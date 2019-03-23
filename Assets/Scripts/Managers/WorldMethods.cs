using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WorldMethods
{
	public static int numberOfFighters = 12;
	public static int traitsPerFighter = 3;
	public static int minLevelForFighters = 2;
	public static int maxLevelForFighters = 3;
	public static int WeekCount = 0;
	public bool readyToStart = false;

	public static GameController GameController { get; set; }
    public static UIController UIController { get; set; }

    public static PlayerResourceManager playerResourceManager { get; set; }
	public static Date RealDate {get; set; }

	public static void SetUpWorld()
	{
		GameController = GameObject.Find ("GameController").GetComponent<GameController>();
        UIController = GameObject.Find("UIController").GetComponent<UIController>();
		RealDate = GameController.RealDate;
        playerResourceManager = GetPlayerResourceManager();

		UIController.RealDate = RealDate;
	}

	public static void DailyTick()
	{
		RealDate = GameController.RealDate;

		int quarterTick = 0;
		while(quarterTick < 4)
		{
            //Sub-daily updates go here
			quarterTick++;
		}
        
        //Daily updates go here
        foreach (GameObject l in GameController.allLocations)
        {
            Location script = l.GetComponent<Location>();
            script.Restock();
            script.UnitsGatherFood();
        }
        GameObject.Find("Home").GetComponent<Home>().ReceiveResources();

        //Check whether a week has passed.
        WeekCount++;
		if (WeekCount == 7)
		{
			WeeklyTick();
			WeekCount = 0;
			GameController.TotalWeekCount++;
		}
		//Make calendar time pass
		if (RealDate.Day < 31)
		{
			RealDate.Day++;
		}
		else
		{
			RealDate.Day = 1;
			if (RealDate.Month < 12)
			{
				MonthlyTick();
				RealDate.Month++;
			}
			else
			{
				YearlyTick();
				RealDate.Month = 1;
				RealDate.Year++;
			}
		}
		GameController.DaysProgressed++;
        UIController.UpdateCalendarDisplay();
    }

	private static void WeeklyTick()
	{
        playerResourceManager.WeeklyTickResources();
        MonoBehaviour.print ("A week has passed");
	}

	private static void MonthlyTick()
	{
		MonoBehaviour.print ("A month has passed");
	}

	private static void YearlyTick()
	{
		MonoBehaviour.print ("A Year has passed");
	}

	public static void PrintDay()
	{
		MonoBehaviour.print("It is Day " + GameController.RealDate.Day);
	}

	public static void PrintMonth()
	{
		MonoBehaviour.print("It is Month " + GameController.RealDate.Month);
	}

	public static void PrintYear()
	{
		MonoBehaviour.print("It is Year " + GameController.RealDate.Year);
	}

	public static void PrintDate()
	{
		MonoBehaviour.print("It is Day " + GameController.RealDate.Day + " of Month " + GameController.RealDate.Month + " of Year " + GameController.RealDate.Year);
	}

    public static GameController GetGameController()
    {
        GameController gameControllerToGet = GameObject.Find("GameController").GetComponent<GameController>();
        return gameControllerToGet;
    }
    public static InputController GetInputController()
    {
        InputController inputControllerToGet = GameObject.Find("InputController").GetComponent<InputController>();
        return inputControllerToGet;
    }
    public static UnitManager GetUnitManager()
    {
        UnitManager unitManagerToGet = GameObject.Find("UnitManager").GetComponent<UnitManager>();
        return unitManagerToGet;
    }
    public static UIController GetUIController()
    {
        UIController uiControllerToGet = GameObject.Find("UIController").GetComponent<UIController>();
        return uiControllerToGet;
    }
    public static PlayerResourceManager GetPlayerResourceManager()
    {
        PlayerResourceManager playerResourceManagerToGet = GameObject.Find("PlayerResourceManager").GetComponent<PlayerResourceManager>();
        return playerResourceManagerToGet;
    }
}
