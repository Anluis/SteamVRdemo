using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandController : MonoBehaviour
{
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;
    private CamControl ctrl;

    HashSet<InteractableItem> ObjectsHoveringOver = new HashSet<InteractableItem>();

    private InteractableItem closestItem;
    private InteractableItem interactingItem;
    private GameObject pickup;
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        ctrl = GetComponent<CamControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }
        if (controller.GetPressDown(triggerButton))
        {
            float minDistance = float.MaxValue;

            float distance;
            foreach (InteractableItem item in ObjectsHoveringOver)
            {
                distance = (item.transform.position - transform.position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = item;
                }
                interactingItem = closestItem;
                if (interactingItem)
                {
                    if (interactingItem.IsInteracting())
                    {
                        interactingItem.EndInteraction(this);
                    }
                    interactingItem.BeginInteraction(this);
                }
            }
        }
        if (controller.GetPressUp(gripButton) && interactingItem != null)
        {
            interactingItem.EndInteraction(this);
        }
        if (controller.GetPressDown(touchPad))
        {
            GameObject.Find("[CameraRig]").SendMessage("Moveforward");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            ObjectsHoveringOver.Add(collidedItem);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            ObjectsHoveringOver.Remove(collidedItem);
        }
    }
}