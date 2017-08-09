using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTower : BaseTower {

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Monster>())
        {
            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target[0] = coll.transform;
            fsm.ChangeState(States.Firing);

        }
    }
}
