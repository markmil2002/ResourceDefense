using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotTarget : MonoBehaviour {
    public static bool collFlag;
	// Use this for initialization
	void Start () {
        collFlag = false;
	}
	void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            collFlag = true;
        }

    }
    void OnTriggerExit(Collider coll)
    {
        collFlag = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
