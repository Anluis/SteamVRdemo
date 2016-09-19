using UnityEngine;
using System.Collections;

public class RandomCube : MonoBehaviour {
    // Use this for initialization
    public Vector2 p;
    public GameObject PrefabCube;
    public int count;
    void Start () {
        count = 0;
    }
	
	// Update is called once per frame
	void Update () { 
        if (count <= 20)
        {
            p = new Vector2(Random.value, Random.value);
            Vector3 pos = new Vector3(p.x, 0, p.y);
            Instantiate(PrefabCube, pos, Quaternion.identity);
            count++;
        }
    }
}
