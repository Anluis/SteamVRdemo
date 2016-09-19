using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WandController : MonoBehaviour
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
        if (controller.GetPressUp(touchPad))
        {
            Vector2 cc = controller.GetAxis();
            float jiaodu = VectorAngle(new Vector2(1, 0), cc);
            Debug.Log(jiaodu);
            if (jiaodu > 45 && jiaodu < 135)
            {
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + '下';
            }
            if (jiaodu < -45 && jiaodu > -135)
            {
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + '上';
            }
            if ((jiaodu < 180 && jiaodu > 135) || (jiaodu < -135 && jiaodu > -180))
            {
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + '左';
            }
            if ((jiaodu > 0 && jiaodu < 45) || (jiaodu > -45 && jiaodu < 0))
            {
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + '右';
            }

        }
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }
        if (controller.GetPressUp(gripButton))
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + gripButton;
        }
        if (controller.GetPressDown(triggerButton))
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + triggerButton;
        }
        if (controller.GetPressDown(ApplicationMenu))
        {
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = gameObject.name + '+' + ApplicationMenu;
        }
    }
    float VectorAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;
    }//转化成角度
}