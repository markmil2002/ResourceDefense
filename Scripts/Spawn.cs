using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class Spawn : BaseEnemy {
    
    public GameObject[] monsterPrefab;
    public static int wave;
    public float interval = 9;
    public int maxEnemies = 10;
    public int enemyCount;
    public static int totalEnemies;
    private bool flag;
    private bool spawning;

    public enum States
    {
        Idle,
        Spawning,
        Upgrading
    }
    private Camera cam;
    private StateMachine<States> fsm;
	// Use this for initialization

    void Awake()
    {
        cam = Camera.main;
        fsm = StateMachine<States>.Initialize(this, States.Idle);
        enemyCount = 0;
    }
	void Start () {
        totalEnemies = 0;
        spawning = false;
        flag = false;
        wave =1;

	}
 
    IEnumerator Idle_Enter()
    {
        Debug.Log("Spawning in 10 seconds");
        yield return new WaitForSeconds(interval);
        fsm.ChangeState(States.Spawning);
    }
    IEnumerator Idle_Exit()
    {
        
        yield return null;
    }
    IEnumerator Spawning_Enter()
    {
        
        Debug.Log("Spawning Now");
        while (enemyCount <= maxEnemies)
        {
            Instantiate(monsterPrefab[0], transform.position, Quaternion.identity);
            totalEnemies += 1;
            enemyCount += 1;
            yield return new WaitForSeconds(2);
        }
        Debug.Log("Spawning Complete");
        yield return new WaitForSeconds(interval);

        fsm.ChangeState(States.Upgrading);
    }
    IEnumerator Upgrading_Enter()
    {
        totalEnemies = 0;
        enemyCount = 0;
        Debug.Log("Enemies Upgrading");
        wave += 1;
        
        GameObject.Find("TextWave").GetComponent<Text>().text = "Wave: " + wave.ToString();
        maxEnemies = maxEnemies + Mathf.FloorToInt(wave / 10);
        //hp = (wave * 2) + Constitution;
        yield return new WaitForSeconds(1);
        ResourceCube.fsm.ChangeState(ResourceCube.States.Gathering);
        fsm.ChangeState(States.Idle);
    }


 


}
