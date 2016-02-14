using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour {

    //This class handles individual bad guys

    public GameObject prefab;
    int baseHealth = 10;
    public float health = 10;

    float regen = 1;



    // Use this for initialization
    void Start()
    {
        Color randColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = randColor;


    }

    // Update is called once per frame
    void Update()
    {
        if (health < 10)
            health += regen * Time.deltaTime;
        if (health > baseHealth)
            health = baseHealth;
    }
}
