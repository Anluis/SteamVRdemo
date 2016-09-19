using UnityEngine;
using System.Collections;

public class RandomCube : MonoBehaviour {
    public Vector2 p;
    public GameObject Cube;
    public int countcube;
    public float Rx, Ry;

    // Use this for initialization
    void Start () {
        countcube = 0;

    }
    // Update is called once per frame
    void Update () {
        if (countcube <= 10)
        {
            p = new Vector2(Random.value * 20, Random.value * 20);
            Vector3 pos = new Vector3(p.x, 100, p.y);
            Instantiate(Cube, pos, Quaternion.identity);
            countcube++;
        }

    }
}
