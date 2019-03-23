using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public bool mouseHovering = false;
    public bool isSelected = false;
    public bool hasReachedTarget = true;
    public GameObject selectionHighlight;
    Vector3 newPosition;
    public GameObject targetObject;
    public Transform target;
    public float unitSpeed = 1.0f;
    private float realUnitSpeed;
    GameController gameController;
    InputController inputController;
    UnitManager unitManager;
    public RevealDetailedInventoryBars inventoryBars;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = WorldMethods.GetGameController();
        inputController = WorldMethods.GetInputController();
        unitManager = WorldMethods.GetUnitManager();
        //Reduce the speed to an appropriate level for the engine
        realUnitSpeed = unitSpeed * gameController.realUnitSpeedFactor;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Make this work!
        if (isSelected && Input.GetMouseButtonDown(1))
        {
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0);
            Debug.Log("Newposition was " + newPosition);
            GameObject newTarget = Instantiate(targetObject);
            newTarget.gameObject.GetComponent<MovementTargetSelfDestruct>().unit = this;
            newTarget.transform.position = newPosition;
            target = newTarget.transform;
        }

        if (!inputController.gamePaused && target != null)
        {
            float modifiedUnitSpeed = realUnitSpeed * gameController.GameSpeed;
            //TODO: Pause movement when game is paused
            transform.position = Vector2.MoveTowards(transform.position, target.position, modifiedUnitSpeed);
        }
    }

    public void Select()
    {
        unitManager.selectedUnit = gameObject;
        foreach (GameObject u in unitManager.allUnits){
            u.GetComponent<UnitMovement>().Deselect();
        }
        isSelected = true;
        selectionHighlight.SetActive(true);
        inventoryBars.EnableBarDisplay();
    }

    public void Deselect()
    {
        isSelected = false;
        if (unitManager.selectedUnit = gameObject)
        {
            unitManager.selectedUnit = null;
        }
        selectionHighlight.SetActive(false);
        inventoryBars.DisableBarDisplay();
    }

    void OnMouseEnter()
    {
        mouseHovering = true;
        inventoryBars.EnableBarDisplay();
    }

    void OnMouseExit()
    {
        mouseHovering = false;
        if (isSelected == false)
        {
            inventoryBars.DisableBarDisplay();
        }
    }

    void OnMouseUpAsButton()
    {
        Select();
    }
}
