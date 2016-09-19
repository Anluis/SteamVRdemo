using UnityEngine;
using System.Collections;

public class RandomSphere : MonoBehaviour {
    public Vector2 p;
    public GameObject Sphere;
    public int countsphere;
    // Use this for initialization
    void Start()
    {
        countsphere = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (countsphere < 10)
        {
            p = new Vector2(Random.value * 20, Random.value * 20);
            Vector3 pos = new Vector3(p.x, 100, p.y);
            Instantiate(Sphere, pos, Quaternion.identity);
            countsphere++;
        }

    }
}
