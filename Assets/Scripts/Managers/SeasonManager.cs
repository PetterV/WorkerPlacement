using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    GameController gameController;
    UIController uiController;

    public bool winter;

    public int winterProgress;
    public int winterDuration;
    public int timeSinceWinter;
    public int winterGrace;

    // Start is called before the first frame update
    public void SetUpSeasons()
    {
        gameController = WorldMethods.GetGameController();
        uiController = WorldMethods.GetUIController();

        winter = true;
        winterProgress = 40;
        winterDuration = 30;

        uiController.UpdateWinterBar();
    }

    public void DailyTickWinter()
    {
        if (!winter)
        {
            WinterBuildup();
        }
        else
        {
            WinterDecay();
        }
        uiController.UpdateWinterBar();
    }

    public void WinterDecay()
    {
        winterProgress -= 1;
        winterDuration += 1;
        int roll;
        if (winterDuration > 60)
        {
            roll = gameController.GameRandom.Next(30);
        }
        else if (winterDuration > 50)
        {
            roll = gameController.GameRandom.Next(50);
        }
        else {
            roll = gameController.GameRandom.Next(100);
        }

        if (roll < 20)
        {
            winterProgress -= 1;
        }

        if (winterProgress <= 0)
        {
            winterProgress = 0;
            EndWinter();
        }
    }

    public void WinterBuildup()
    {
        if (winterProgress < 100)
        {
            if (winterGrace > 0)
            {
                winterGrace -= 1;
            }
            else
            {
                RandomWinterProgress();
            }
            timeSinceWinter += 1;
        }
        else
        {
            winterProgress = 100;
            StartWinter();
        }
    }

    void RandomWinterProgress()
    {
        int roll = gameController.GameRandom.Next(100);
        int target;
        if (timeSinceWinter > 225)
        {
            target = 70;
        }
        else if (timeSinceWinter > 175)
        {
            target = 40;
        }
        else
        {
            target = 20;
        }

        //Check roll
        if (roll < target)
        {
            winterProgress += 1;
        }
    }

    void StartWinter()
    {
        winter = true;
        timeSinceWinter = 0;
        winterDuration = 0;
        uiController.ActivateWinterMarker();
        //TODO: Winter effects
    }

    void EndWinter()
    {
        winter = false;
        winterGrace = 80;
        uiController.DeactivateWinterMarker();
    }
}
