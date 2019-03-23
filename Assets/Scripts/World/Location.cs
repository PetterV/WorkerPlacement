using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    UnitManager unitManager;
    public List<GameObject> unitsInRange = new List<GameObject>();

    public int food;
    public int wood;
    public int silver;

    public int maxFood;
    public int maxWood;
    public int maxSilver;

    //Determines how much is generated in a day
    public int foodRecoverySpeed;
    public int woodRecoverySpeed;
    public int silverRecoverySpeed;

    public int collectSpeed;

    //Script for the fillbar
    public LocationFillBar locationFillBar;

    // Start is called before the first frame update
    void Start()
    {
        unitManager = GameObject.Find("UnitManager").GetComponent<UnitManager>();
    }

    /*public void SetAsTarget()
    {
        GameObject unitToMove = unitManager.selectedUnit;
        unitToMove.GetComponent<UnitMovement>().target.position = transform.position;
    }*/

    public void Restock()
    {
        int i = 0;
        while (i < foodRecoverySpeed)
        {
            if (food < maxFood)
            {
                food += 1;
                SetFoodFillbar();
            }
            i++;
        }

        i = 0;
        while (i < woodRecoverySpeed)
        {
            if (wood < maxWood)
            {
                wood += 1;
                SetWoodFillbar();
            }
            i++;
        }

        i = 0;
        while (i < silverRecoverySpeed)
        {
            if (silver < maxSilver)
            {
                silver += 1;
                SetSilverFillbar();
            }
            i++;
        }
    }
    
    public void UnitsGatherFood()
    {
        foreach (GameObject u in unitsInRange)
        {
            UnitInventory unitInventory = u.GetComponent<UnitInventory>();
            if (food > collectSpeed)
            {
                unitInventory.CollectFood(collectSpeed);
                food = food - collectSpeed;
                SetFoodFillbar();
            }
            else if(food > 0)
            {
                unitInventory.CollectFood(food);
                food = 0;
                SetFoodFillbar();
            }

            if (wood > collectSpeed)
            {
                unitInventory.CollectWood(collectSpeed);
                wood = wood - collectSpeed;
                SetWoodFillbar();
            }
            else if (wood > 0)
            {
                unitInventory.CollectWood(wood);
                wood = 0;
                SetWoodFillbar();
            }

            if (silver > collectSpeed)
            {
                unitInventory.CollectSilver(collectSpeed);
                silver = silver - collectSpeed;
                SetSilverFillbar();
            }
            else if (silver > 0)
            {
                unitInventory.CollectSilver(silver);
                silver = 0;
                SetSilverFillbar();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision registered");
        //TODO: How do you get the *other* collider object?
        if(col.gameObject.tag == "Unit")
        {
            unitsInRange.Add(col.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        //TODO: How do you get the *other* collider object?
        if (col.gameObject.tag == "Unit")
        {
            unitsInRange.Remove(col.gameObject);
        }
    }

    void SetFoodFillbar()
    {
        float value = (float)food / (float)maxFood;
        locationFillBar.SetFillBar(value);
    }
    void SetWoodFillbar()
    {
        float value = (float)wood / (float)maxWood;
        locationFillBar.SetFillBar(value);
    }
    void SetSilverFillbar()
    {
        float value = (float)silver / (float)maxSilver;
        locationFillBar.SetFillBar(value);
    }
}
