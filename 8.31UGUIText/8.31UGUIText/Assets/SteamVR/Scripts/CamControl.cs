using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
    public Rigidbody m_Rigidboby;
    public Transform m_Transform;
    public bool check;
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Rigidboby = gameObject.GetComponent<Rigidbody>();
        check = false;
    }
	
public void Moveforward()
    {
        m_Rigidboby.MovePosition(m_Transform.position + Vector3.forward * 0.2f);
        Debug.Log("OK!");
    }

    void Update () {
            
            if (Input.GetKey(KeyCode.W))
            {
                m_Rigidboby.MovePosition(m_Transform.position + Vector3.forward * 0.2f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_Rigidboby.MovePosition(m_Transform.position + Vector3.back * 0.2f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_Rigidboby.MovePosition(m_Transform.position + Vector3.left * 0.2f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_Rigidboby.MovePosition(m_Transform.position + Vector3.right * 0.2f);
            }
    }
}
