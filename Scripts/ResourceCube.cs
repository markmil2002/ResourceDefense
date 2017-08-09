using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class ResourceCube : MonoBehaviour {
    public enum States
    {
        Idle,
        Full,
        Damaged,
        Severe,
        Emptied,
        Gathering,
        TakeDamage
    }
    private static float currentHealth;
    private float maxHealth;
    public static StateMachine<States> fsm;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        currentHealth = 100;
        maxHealth = 100;
        fsm = StateMachine<States>.Initialize(this, States.Full);
    }
    void OnTriggerEnter(Collider coll)
    {
        
    }
    void OnTriggerExit(Collider coll)
    {

    }
    private void Full_Enter()
    {
        Debug.Log("Full Health");
    }
    private void Damaged_Enter()
    {
        Debug.Log("Resource production Decreased" + currentHealth);
        GameObject.Find("ResourceCube").transform.position = new Vector3(GameObject.Find("ResourceCube").transform.position.x, GameObject.Find("ResourceCube").transform.position.y-.05f, GameObject.Find("ResourceCube").transform.position.z);

        fsm.ChangeState(States.Idle);
    }
    private void Severe_Enter()
    {
        Debug.Log("Resource Center Severely Damaged");
        if (currentHealth <= 0)
        {
            fsm.ChangeState(States.Emptied);
        }
        else
        {
            fsm.ChangeState(States.Idle);
        }
    }
    private void Emptied_Enter()
    {
        Debug.Log("Resource Center Destroyed");
        Destroy(gameObject);
    }
    public static void Gathering_Enter()
    {
        Debug.Log("Gathering Resources");
        new WaitForSeconds(3);
        Player.resources = (Spawn.wave * 10);
        fsm.ChangeState(States.Idle);
    }
    private void TakeDamage_Enter()
    {
        Debug.Log("Damage Taken");
        currentHealth = currentHealth - Monster.carryWeight;

        if (currentHealth < 40)
        {
            fsm.ChangeState(States.Severe);
        }
        else
        {
            fsm.ChangeState(States.Damaged);

        }
    }
}
