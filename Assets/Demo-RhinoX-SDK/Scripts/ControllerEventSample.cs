using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerEventSample : MonoBehaviour
{
    public TextMesh TextOnController;
    int TriggerClickTimes = 0;
    int TouchPadClickTimes = 0;
    int HomeClickTimes = 0;
    int AppClickTimes = 0;

    private void Start()
    {
        
    }

    public void OnControllerTriggerClick()
    {
        TextOnController.text = "Controller Trigger Clicked: \n" + (++TriggerClickTimes).ToString();
    }

    public void OnControllerTouchPadClick()
    {
        TextOnController.text = "Controller TouchPad Clicked: \n" + (++TouchPadClickTimes).ToString();
    }

    public void OnControllerHomeClick()
    {
        TextOnController.text = "Controller Home Clicked: \n" + (++HomeClickTimes).ToString();
    }

    public void OnControllerAppClick()
    {
        TextOnController.text = "Controller App Clicked: \n" + (++AppClickTimes).ToString();
    }
}
