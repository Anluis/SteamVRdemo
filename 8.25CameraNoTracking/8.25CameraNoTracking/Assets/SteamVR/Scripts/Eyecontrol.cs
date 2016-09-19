using UnityEngine;
using System.Collections;

public class Eyecontrol : MonoBehaviour {
    public Rigidbody m_Rigidboby;
    public Transform m_Transform;
    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Rigidboby = gameObject.GetComponent<Rigidbody>();
       // pre_Transform.rotation = new Vector3(-9.388f, -99.32001f, 0.339f);
        Debug.Log("Start");

    }
	
	// Update is called once per frame
	void Update () {
        m_Transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        m_Transform.rotation = Quaternion.Euler(0, 90, 0); 
        Debug.Log(m_Transform.position.ToString());

    }
}
