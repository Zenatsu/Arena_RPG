using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DictionaryExample : MonoBehaviour {

    Dictionary<string, int> dictionary = new Dictionary<string, int>();

    static void Main()
    {
        Dictionary<string, int> d = new Dictionary<string, int>();

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(80, 80, 30, 30), "PrintKey"))
        {
            Debug.Log(dictionary)
        }
    }

    void AddDictionary(string key, int value)
    {
        dictionary.Add(key, value);
    }
    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
