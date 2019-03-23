using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelButton : MonoBehaviour {

	public GameObject PanelToClose;

	public void ClosePanel(){
        //TODO: Disabled awaiting a tooltip system
        //gameObject.GetComponent<TooltipRegistration>().CloseTooltip();
		PanelToClose.SetActive (false);
	}

	void Update(){
		gameObject.SetActive (PanelToClose.activeSelf);
	}
}
