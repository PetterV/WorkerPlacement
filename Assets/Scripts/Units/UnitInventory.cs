using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInventory : MonoBehaviour
{
    public int food;
    public int wood;
    public int silver;
    int inventorySize = 0;
    int maxInventorySize = 50;

    PlayerResourceManager playerResourceManager;

    public LocationFillBar inventoryBar;
    public LocationFillBar foodBar;
    public LocationFillBar woodBar;
    public LocationFillBar silverBar;

    void Awake()
    {
        playerResourceManager = WorldMethods.GetPlayerResourceManager();
    }

    public void CollectFood(int amount)
    {
        int i = 0;
        while (i < amount){
            if (inventorySize < maxInventorySize)
            {
                food += 1;
                inventorySize += 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }
    public void CollectWood(int amount)
    {
        int i = 0;
        while (i < amount)
        {
            if (inventorySize < maxInventorySize)
            {
                wood += 1;
                inventorySize += 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }
    public void CollectSilver(int amount)
    {
        int i = 0;
        while (i < amount)
        {
            if (inventorySize < maxInventorySize)
            {
                silver += 1;
                inventorySize += 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }
    public void RemoveFood(int amount)
    {
        int i = 0;
        while (i < amount) {
            if (food > 0)
            {
                food -= 1;
                inventorySize -= 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }
    public void RemoveWood(int amount)
    {
        int i = 0;
        while (i < amount)
        {
            if (wood > 0)
            {
                wood -= 1;
                inventorySize -= 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }
    public void RemoveSilver(int amount)
    {
        int i = 0;
        while (i < amount)
        {
            if (silver > 0)
            {
                silver -= 1;
                inventorySize -= 1;
            }
            i += 1;
        }
        UpdateInventoryBar();
        //TODO: Warning if max inventory size has been surpassed
    }

    void UpdateInventoryBar()
    {
        float value = (float)inventorySize / (float)maxInventorySize;
        inventoryBar.SetFillBar(value);

        float foodValue = (float)food / (float)maxInventorySize;
        foodBar.SetFillBar(foodValue);
        float woodValue = (float)wood / (float)maxInventorySize;
        woodBar.SetFillBar(woodValue);
        float silverValue = (float)silver / (float)maxInventorySize;
        silverBar.SetFillBar(silverValue);
    }
}
