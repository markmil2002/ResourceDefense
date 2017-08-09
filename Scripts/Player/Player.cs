using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseClass {
    public static int resources;
    public static int bulletLevel;
    public static int towerLevel;
    public static int strength;
    public static int speed;
    public static int agility;
    public static int dexterity;
    public static int constitution;
    public static string playerClass;

    public int roundsPerMagazine;
    public int reloadTime;
    public int roundsPerMinute;
    public int barrelLength;
    public int caliber;
    public int negligentDischarge;
    public int killRadius;
    public int shotsTillCleaning;
    public int cleaningTime;
    public int range;
	// Use this for initialization
	void Start () {
        //add scripting to add values from playfab
        strength = 1;
        speed = 1;
        //!-DELETE THIS----------------------------------------------------
        Faction = "Nerds";
        //!-DELETE THIS----------------------------------------------------
        if (Faction == "Nerds")
        {
            speed = speed + 2;
        }
        else if (Faction == "Bullies")
        {
            strength = strength + 2;
        }
        if (PlayerClass == "AssaultMan")
        {
            roundsPerMagazine = 28;
            reloadTime = 3;
            roundsPerMinute = 15;
            barrelLength = 20;
            caliber = 223;
            negligentDischarge = 2;
            killRadius = 1;
            shotsTillCleaning = 300;
            cleaningTime = 3;
            //range
        }
        else if (PlayerClass == "GrenadeMan")
        {
            roundsPerMagazine = 8;
            reloadTime = 5;
            roundsPerMinute = 5;
            barrelLength = 15;
            caliber = 400;
            negligentDischarge = 4;
            killRadius = 15;
            shotsTillCleaning = 300;
            cleaningTime = 3;
            //Maxrange = 437
        }
        else if (PlayerClass == "MachineGunner")
        {
            roundsPerMagazine = 200;
            reloadTime = 4;
            roundsPerMinute = 200;
            barrelLength = 25;
            caliber = 30;
            range = 875;
            negligentDischarge = 1;
            killRadius = 1;
            shotsTillCleaning = 1000;
            cleaningTime = 3;
            //maxrange = 800

        }
        else if (PlayerClass == "Sniper")
        {
            roundsPerMagazine = 1;
            reloadTime = 1;
            roundsPerMinute = 20;
            barrelLength = 24;
            caliber = 33;
            range = 1500;
            negligentDischarge = 0;
            killRadius = 1;
            shotsTillCleaning = 10000;
            cleaningTime = 4;
        }

        bulletLevel = 1;
        towerLevel = 1;
        
        constitution = 1;
        dexterity = 1;
        resources = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
