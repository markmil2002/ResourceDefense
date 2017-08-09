using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
public class Bullet : MonoBehaviour {
    public enum States
    {
        flying,
        hit
    }
    public float speed = 10;
    public static int damage;
    public static int level;
    public Transform[] target;

    void FixedUpdate()
    {
        if (target[0])
        {
            Vector3 dir = target[0].position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void start()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        damage = 2*Player.bulletLevel;
        Debug.Log(damage);
        if (coll.tag == "Enemy")
        {
            int hp;
            hp = int.Parse(coll.GetComponentInChildren<TextMesh>().text);
            //if (health)
            for (int n = 0; n < 3; n++)
            {
                hp = hp - damage;
                coll.GetComponentInChildren<TextMesh>().text = hp.ToString();
                new WaitForSeconds(3);
            }
            Destroy(gameObject);
            if (hp <= 0)
            {
                Destroy(coll.gameObject);
                Spawn.totalEnemies = Spawn.totalEnemies - 1;
            }
        }
    }
}
