using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTargetSelfDestruct : MonoBehaviour
{
    public UnitMovement unit;

    // Update is called once per frame
    void Update()
    {
        if (unit.target != gameObject.transform)
        {
            Destroy(gameObject);
        }
    }
}
