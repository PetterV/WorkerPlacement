using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    
    public int dayCount = 0;
	public int monthCount = 0;
	public int yearCount = 0;

    TextMeshProUGUI DaysCounter;
    TextMeshProUGUI MonthsCounter;
    TextMeshProUGUI YearsCounter;
    TextMeshProUGUI GameSpeedDisplay;
    TextMeshProUGUI authorityNumber;
    TextMeshProUGUI populationNumber;
    TextMeshProUGUI foodNumber;
    TextMeshProUGUI woodNumber;
    TextMeshProUGUI silverNumber;

    int GameSpeed;
	public Date RealDate;
	GameController GameController;
    InputController inputController;
    PlayerResourceManager playerResourceManager;
    SeasonManager seasonManager;

    public GameObject pauseBoard;

    //Winter
    public Image winterBar;
    public Image winterMarker;
    public Color winterColour;
    public Color springColour;

	public void UIControllerSetup(){
		GameController = GameObject.Find ("GameController").GetComponent<GameController> ();
        inputController = GameObject.Find("InputController").GetComponent<InputController>();
        playerResourceManager = WorldMethods.GetPlayerResourceManager();

        pauseBoard = GameObject.Find("PauseBoard");

        GameSpeedDisplay = GameObject.Find("GameSpeedDisplay").GetComponent<TextMeshProUGUI> ();
		DaysCounter = GameObject.Find ("DaysCounter").GetComponent<TextMeshProUGUI>();
		MonthsCounter = GameObject.Find ("MonthsCounter").GetComponent<TextMeshProUGUI>();
		YearsCounter = GameObject.Find ("YearsCounter").GetComponent<TextMeshProUGUI>();

        authorityNumber = GameObject.Find("AuthorityNumber").GetComponent<TextMeshProUGUI>();
        populationNumber = GameObject.Find("PopulationNumber").GetComponent<TextMeshProUGUI>();
        foodNumber = GameObject.Find("FoodNumber").GetComponent<TextMeshProUGUI>();
        woodNumber = GameObject.Find("WoodNumber").GetComponent<TextMeshProUGUI>();
        silverNumber = GameObject.Find("SilverNumber").GetComponent<TextMeshProUGUI>();

        seasonManager = WorldMethods.GetSeasonManager();

        RealDate = GameController.RealDate;
	}
    
	void Update(){
        if (inputController.gamePaused && !pauseBoard.activeSelf)
        {
            pauseBoard.SetActive(true);
        }
        else if (!inputController.gamePaused && pauseBoard.activeSelf)
        {
            pauseBoard.SetActive(false);
        }
	}

    public void UpdateCalendarDisplay()
    {
        dayCount = RealDate.Day;
        monthCount = RealDate.Month;
        yearCount = RealDate.Year;
        GameSpeed = GameController.GameSpeed;
        DaysCounter.text = dayCount.ToString();
        MonthsCounter.text = monthCount.ToString();
        YearsCounter.text = yearCount.ToString();
        GameSpeedDisplay.text = GameSpeed.ToString();
    }

    public void UpdateResourceDisplay()
    {
        authorityNumber.text = playerResourceManager.authority.ToString();
        populationNumber.text = playerResourceManager.population.ToString();
        foodNumber.text = playerResourceManager.food.ToString();
        woodNumber.text = playerResourceManager.wood.ToString();
        silverNumber.text = playerResourceManager.silver.ToString();
    }

    public void ActivateWinterMarker()
    {
        winterMarker.gameObject.SetActive(true);
    }
    public void DeactivateWinterMarker()
    {
        winterMarker.gameObject.SetActive(false);
    }
    public void UpdateWinterBar()
    {
        float progressRate = (float)seasonManager.winterProgress / 100f;
        Color progressColor = Color.Lerp(springColour, winterColour, progressRate);
        winterBar.fillAmount = progressRate;
        winterBar.color = progressColor;
    }
}
