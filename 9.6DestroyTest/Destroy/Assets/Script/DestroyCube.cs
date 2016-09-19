using UnityEngine;
using System.Collections;

public class DestroyCube : MonoBehaviour {

    public void Des()
    {
        GameObject.Find("Controller").SendMessage("DesCube");
        Destroy(this.gameObject);
    }
}
