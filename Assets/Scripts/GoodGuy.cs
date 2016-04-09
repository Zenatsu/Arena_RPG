using UnityEngine;
using System.Collections;

public class GoodGuy : MonoBehaviour {

    float health = 10;
    float regen = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health += regen * Time.deltaTime;
    }

}
