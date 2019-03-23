using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitManager : MonoBehaviour
{
    public GameObject debugSelectedUnit;
    public GameObject selectedUnit;
    public GameObject unitPrefab;
    public List<GameObject> allUnits;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] startingUnits = GameObject.FindGameObjectsWithTag("Unit");
        allUnits = startingUnits.OfType<GameObject>().ToList();
    }

    public void CreateUnit()
    {
        GameObject newUnit = Instantiate(unitPrefab);
        allUnits.Add(newUnit);
    }
}
