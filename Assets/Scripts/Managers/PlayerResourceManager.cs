using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public int wood;
    public int silver;
    public int food;
    public int population;
    public int authority;

    public int startingAuthority;
    public int startingPopulation;
    public int startingFood;
    public int startingWood;
    public int startingSilver;

    public int foodLossBase;
    public int woodLossBase;
    public int populationLossBase;

    GameController gameController;
    UIController uiController;

    // Start is called before the first frame update
    public void SetUpResources()
    {
        gameController = WorldMethods.GetGameController();
        uiController = WorldMethods.GetUIController();

        authority = startingAuthority;
        population = startingPopulation;
        food = startingFood;
        wood = startingWood;
        silver = startingSilver;

        uiController.UpdateResourceDisplay();
    }

    public void AddFood(int amount)
    {
        food = food + amount;
        //TODO: Display change notifications
        uiController.UpdateResourceDisplay();
    }
    public void AddSilver(int amount)
    {
        silver = silver + amount;
        //TODO: Display change notifications
        uiController.UpdateResourceDisplay();
    }
    public void AddWood(int amount)
    {
        wood = wood + amount;
        //TODO: Display change notifications
        uiController.UpdateResourceDisplay();
    }
    public void AddPopulation(int amount)
    {
        population += amount;
        //TODO: Display change notifications
        uiController.UpdateResourceDisplay();
    }
    public void AddAuthority(int amount)
    {
        authority += amount;
        //TODO: Display change notifications
        uiController.UpdateResourceDisplay();
    }

    public void WeeklyTickResources()
    {
        WeeklyFoodLoss();
    }

    public void WeeklyFoodLoss()
    {
        int foodToLose = 0 - foodLossBase;
        AddFood(foodToLose);
        if (food < 0)
        {
            food = 0;
            PopulationLossFromFood();
        }
    }

    public void PopulationLossFromFood()
    {
        int populationToLose = 0 - populationLossBase;
        AddPopulation(populationToLose);
    }
}
