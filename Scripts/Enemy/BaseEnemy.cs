using System.Collections;
using System.Collections.Generic;
using MonsterLove.StateMachine;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    public static int maxHP;
    public static int currentHP;
    private float strength;
    private int constitution;
    private float agility;
    private float speed;
    private float dexterity;
    public static float carryWeight;
    private float attack;
    public enum states
    {
        FullHealth,
        Damaged,
        Dead,
        Buffed,
        Attacked,
        Hit,
        Dodged,
        Attacking,
        Escaping
    }

    public float Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Constitution
    {
        get { return constitution; }
        set { constitution = value; }
    }
    public float Agility
    {
        get { return agility; }
        set { agility = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }


    void awake()
    {
        Strength = 1;
        Constitution = 1;
        Agility = 1;
        Speed = 1;
        Dexterity = 1;
        carryWeight = 10;
        

    }
	// Use this for initialization
	void Start () {
        

        
	}
    
	
	// Update is called once per frame
	void Update () {
		
	}

}
