using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Trigger Enter");
        if (coll.tag == "Enemy")
        {
            Debug.Log("Enemy Collision");
            StartCoroutine(Tower.Shoot(coll.gameObject));
        }
        yield return null;
    }
}
