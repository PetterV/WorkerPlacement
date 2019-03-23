using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationFillBar : MonoBehaviour
{
    public Transform fullFillImage;
    public Transform fillImage;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newScale = fillImage.localScale;
        newScale.x = 0;
        fillImage.localScale = newScale;
    }

    // Update is called once per frame
    public void SetFillBar(float fillAmount)
    {
        fillAmount = Mathf.Clamp01(fillAmount);

        Vector3 newScale = fillImage.localScale;
        newScale.x = fullFillImage.localScale.x * fillAmount;
        fillImage.localScale = newScale;
    }
}
