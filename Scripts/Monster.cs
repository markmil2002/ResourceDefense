using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class Monster : BaseEnemy {

	// Use this for initialization
	void Start () {
        carryWeight = 10;
        maxHP = (Spawn.wave*Spawn.wave)+(Spawn.wave*2)+Constitution;
        currentHP = maxHP;
        GetComponentInChildren<TextMesh>().text = maxHP.ToString();
        GameObject castle = GameObject.Find("ResourceCube");
        if (castle)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = castle.transform.position;
        }
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "ResourceCube")
        {
            ResourceCube.fsm.ChangeState(ResourceCube.States.TakeDamage);
            Destroy(gameObject);
        }
    }
    void Awake()
    {

    }
	
}
