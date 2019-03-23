using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealDetailedInventoryBars : MonoBehaviour
{
    public SpriteRenderer foodBar;
    public SpriteRenderer woodBar;
    public SpriteRenderer silverBar;
    public void EnableBarDisplay()
    {
        Debug.Log("Mouse enter registered");
        foodBar.enabled = true;
        woodBar.enabled = true;
        silverBar.enabled = true;
    }
    public void DisableBarDisplay()
    {
        Debug.Log("Mouse exit registered");
        foodBar.enabled = false;
        woodBar.enabled = false;
        silverBar.enabled = false;
    }
}
