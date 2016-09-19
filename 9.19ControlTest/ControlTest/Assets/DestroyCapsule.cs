using UnityEngine;
using System.Collections;

public class DestroyCapsule: MonoBehaviour {

    public void Des()
    {
        GameObject.Find("Controller").SendMessage("DesCapsule");
        Destroy(this);
    }
}
