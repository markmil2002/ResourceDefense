using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDOT : BaseTower{
    public GameObject removeArea;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Monster>() & !GetComponentInChildren<Collider>().bounds.Contains(coll.transform.position))
        {

            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target[0] = coll.transform;
            fsm.ChangeState(States.Firing);

        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
