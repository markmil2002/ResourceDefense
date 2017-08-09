using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class Tower3D : MonoBehaviour {
    public GameObject[] bulletPrefab;
    private StateMachine<States> fsm;
    private int upgradeCost;
    public enum States
    {
        Building,
        Idle,
        Reloading,
        Firing,
        Upgrading,
        Buffed
    }
    IEnumerator Building_Enter()
    {
        Debug.Log("Building complete in 4 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Building complete in 3 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Building complete in 2 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Building complete in 1 seconds");
        yield return new WaitForSeconds(1);
        
        fsm.ChangeState(States.Idle);
    }
    void Idle_Enter()
    {
        
    }
    void Idle_Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
    IEnumerator Reloading_Enter()
    {
        Debug.Log("Reloading complete in 5 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading complete in 4 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading complete in 3 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading complete in 2 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading complete in 1 seconds");
        yield return new WaitForSeconds(1);
        fsm.ChangeState(States.Idle);
    }
    void Firing_Enter()
    {
        
        fsm.ChangeState(States.Reloading);
    }
    IEnumerator Upgrading_Enter()
    {
        Bullet.damage = (Bullet.damage ^ 2) + (Bullet.level * Bullet.damage) + Player.strength;
        yield return new WaitForSeconds(10);
        upgradeCost = Mathf.FloorToInt((1.085f * upgradeCost) + (upgradeCost/2f));
        yield return null;
    }
    IEnumerator Buffed_Enter()
    {
        yield return null;
    }

    void Start()
    {
        
    }
    public float rotationSpeed = 35;
	// Update is called once per frame
	void Update () {
        
	}
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Monster>())
        {
            
            GameObject g = (GameObject)Instantiate(bulletPrefab[0], transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target[0] = coll.transform;
            fsm.ChangeState(States.Firing);

        }
    }
    void Awake()
    {
        fsm = StateMachine<States>.Initialize(this, States.Building);
    }
}
