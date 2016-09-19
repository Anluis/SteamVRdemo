using UnityEngine;
using VRTK;

public class VRTK_ControllerPointerEvents_ListenerExample : MonoBehaviour
{
    public GameObject objCtrl;

    private void Start()
    {
        if (GetComponent<VRTK_SimplePointer>() == null)
        {
            Debug.LogError("VRTK_ControllerPointerEvents_ListenerExample is required to be attached to a Controller that has the VRTK_SimplePointer script attached to it");
            return;
        }

        //Setup controller event listeners
        GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
        GetComponent<VRTK_SimplePointer>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
        GetComponent<VRTK_SimplePointer>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
    }

    private void DebugLogger(uint index, string action, Transform target, float distance, Vector3 tipPosition)
    {
        string targetName = (target ? target.name : "<NO VALID TARGET>");
        if (target.gameObject.name != "Floor") {
            if (target.gameObject.tag == "Sphere")
            {
                objCtrl.GetComponent<RandomSphere>().countsphere--;
                Debug.Log(target.gameObject);
                Destroy(target.gameObject);
            }
            if (target.gameObject.tag == "Cube")
            {
                objCtrl.GetComponent<RandomCube>().countcube--;
                Debug.Log(target.gameObject);
                Destroy(target.gameObject);
            }
            if (target.gameObject.tag == "Capsule")
            {
                objCtrl.GetComponent<RandomCapsule>().countcapsule--;
                Debug.Log(target.gameObject);
                Destroy(target.gameObject);
            }
        }
        //Debug.Log("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named " + targetName + " - the pointer tip position is/was: " + tipPosition);
        
    }

    private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER IN", e.target, e.distance, e.destinationPosition);
    }

    private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER OUT", e.target, e.distance, e.destinationPosition);
    }

    private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER DESTINATION", e.target, e.distance, e.destinationPosition);
    }
}