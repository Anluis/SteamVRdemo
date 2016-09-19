using UnityEngine;
using System.Collections;

public class RandomCapsule : MonoBehaviour {
    public Vector2 p;
    public GameObject Capsule;
    public int countcapsule;
    // Use this for initialization
    void Start()
    {
        countcapsule = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (countcapsule <= 10)
        {
            p = new Vector2(Random.value * 20, Random.value * 20);
            Vector3 pos = new Vector3(p.x, 100, p.y);
            Instantiate(Capsule, pos, Quaternion.identity);
            countcapsule++;
        }

    }
}
