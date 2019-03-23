using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    UnitManager unitManager;
    PlayerResourceManager playerResourceManager;
    public List<GameObject> unitsInRange = new List<GameObject>();
    public int foodReceptionSpeed = 1;
    public int woodReceptionSpeed = 1;
    public int silverReceptionSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        unitManager = GameObject.Find("UnitManager").GetComponent<UnitManager>();
        playerResourceManager = WorldMethods.GetPlayerResourceManager();
    }
    
    /*public void SetAsTarget()
    {
        GameObject unitToMove = unitManager.selectedUnit;
        unitToMove.GetComponent<UnitMovement>().target.position = transform.position;
    }*/
    
    public void ReceiveResources()
    {
        foreach(GameObject u in unitsInRange)
        {
            //TODO: Value change notifications
            UnitInventory uInventory = u.GetComponent<UnitInventory>();
            //Food
            if (uInventory.food > foodReceptionSpeed)
            {
                playerResourceManager.AddFood(foodReceptionSpeed);
                uInventory.RemoveFood(foodReceptionSpeed);
            }
            else if (uInventory.food > 0)
            {
                playerResourceManager.AddFood(uInventory.food);
                int foodToRemove = uInventory.food;
                uInventory.RemoveFood(foodToRemove);
            }
            //Wood
            if (uInventory.wood > woodReceptionSpeed)
            {
                playerResourceManager.wood += woodReceptionSpeed;
                uInventory.RemoveWood(woodReceptionSpeed);
            }
            else if (uInventory.wood > 0)
            {
                playerResourceManager.wood += uInventory.wood;
                int woodToRemove = uInventory.wood;
                uInventory.RemoveWood(woodToRemove);
            }
            //Silver
            if (uInventory.silver > silverReceptionSpeed)
            {
                playerResourceManager.silver += silverReceptionSpeed;
                uInventory.RemoveSilver(silverReceptionSpeed);
            }
            else if (uInventory.silver > 0)
            {
                playerResourceManager.silver += uInventory.silver;
                int silverToRemove = uInventory.silver;
                uInventory.RemoveSilver(silverToRemove);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision registered");
        //TODO: How do you get the *other* collider object?
        if (col.gameObject.tag == "Unit")
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
}
