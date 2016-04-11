using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class BadGuy : MonoBehaviour {

    //This class handles individual bad guys

    public GameObject prefab;
    TargetSelection targetScript; 

    public int hp;

    // Use this for initialization
    void Start()
    {
        Color randColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = randColor;


    }


// Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {
            Destroy(gameObject);
        }
        
    }
}
