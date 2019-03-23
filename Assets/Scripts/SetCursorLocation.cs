using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCursorLocation : MonoBehaviour
{
    Vector3 cursorPosition;

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition = new Vector3(cursorPosition.x, cursorPosition.y, 0);
        transform.position = cursorPosition;
    }
}
