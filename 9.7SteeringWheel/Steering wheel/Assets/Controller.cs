using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("方向盘参数" + Input.GetAxis("Horizontal"));
        Debug.Log("Fire1 " + Input.GetAxis("Fire1"));
    }
}
