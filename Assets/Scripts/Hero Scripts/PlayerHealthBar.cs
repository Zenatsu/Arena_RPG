using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public GameObject player;
    public GoodGuy playerScript;
    public Slider HPBar;

    // Use this for initialization
    void Start ()
    {
        playerScript = player.GetComponentInParent<GoodGuy>();       
        HPBar.maxValue = playerScript.maxHP;

    }

	// Update is called once per frame
	void Update ()
    {

        HPBar.value = playerScript.currentHP;
                
    }
}
