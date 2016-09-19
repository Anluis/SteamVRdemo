using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private Valve.VR.EVRButtonId ApplicationMenu = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    HashSet<InteractableItem> ObjectsHoveringOver = new HashSet<InteractableItem>();

    private InteractableItem closestItem;
    private InteractableItem interactingItem;
    private GameObject pickup;
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }
        if (controller.GetPressDown(touchPad))
        {
            Debug.Log(gameObject.name + '+' + touchPad);

            GameObject.Find("Canvas/Text").GetComponent<Text>().text= "1111";

        }
        if (controller.GetPressUp(gripButton))
        {
            Debug.Log(gameObject.name + '+' + gripButton);
        }
        if (controller.GetPressDown(triggerButton))
        {
            Debug.Log(gameObject.name + '+' + triggerButton);
        }
        if (controller.GetPressDown(ApplicationMenu))
        {
            Debug.Log(gameObject.name + '+' + ApplicationMenu);
        }


    }
}