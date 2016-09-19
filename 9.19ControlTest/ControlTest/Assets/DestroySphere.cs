using UnityEngine;
using System.Collections;

public class DestroySphere : MonoBehaviour {
    public void Des()
    {
        GameObject.Find("Controller").SendMessage("DesSphere");
        Destroy(this.gameObject);
    }
    // Use this for initialization
}
