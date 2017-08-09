using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class Tower : MonoBehaviour {
    public static Vector3 location;
    public static GameObject ammo;
    // Use this for initialization
    private StateMachine<States> fsm;
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
    IEnumerator Reloading_Enter()
    {
        yield return null;
    }
    void Firing_Enter()
    {

    }
    IEnumerator Upgrading_Enter()
    {
        yield return null;
    }
    IEnumerator Buffed_Enter()
    {
        yield return null;
    }
	void Start () {
        fsm = StateMachine<States>.Initialize(this, States.Building);
	}
	void Update () {
		
	}
    public static IEnumerator Shoot(GameObject target)
    {
        GameObject Ammo = Instantiate(Resources.Load("ammo"), location, Quaternion.identity) as GameObject;
        while(Vector3.Distance(location, target.transform.position) < .1f)
        {

        }
        yield return null;
    }
    void Awake()
    {
        
        ammo = new GameObject();
        location = this.transform.position;
    }
}
