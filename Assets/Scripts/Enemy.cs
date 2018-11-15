using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    PlayerController hero;

    public const int maxHP = 100;
    public int currentHP = maxHP;
    public int damage;
    public RectTransform hpBar;
    public float secondsBetweenShots;

    private float timestamp;
    private Transform player;
    private float hpBarSize;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        Dead();
        FollowHero();
	}

    void FollowHero()
    {
        Debug.DrawRay(transform.position, player.position, Color.yellow);
        float distance = Vector3.Distance(player.position, transform.position);

        if(player != null)
        {
            if (distance <= 5 && agent)
            {
                agent.SetDestination(player.position);
                if(Time.time >= timestamp)
                {
                    Attack();
                }
            }
            else if (distance >= 5)
            {
                agent.SetDestination(originalPos);
            }
        }
    }

    void Attack()
    {
        RaycastHit hit;

        int layermask = LayerMask.GetMask("Player");

        if (Physics.Raycast(transform.position, player.position, out hit, 2f, layermask))
        {
            hero = hit.collider.GetComponent<PlayerController>();
            hero.Damage(damage);
            Debug.Log("Hit Player");
        }

        timestamp = Time.time + secondsBetweenShots;

    }

    //Ga weg als de hp aan 0 is of eronder
    void Dead()
    {
        if(currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Dmg functie die aangeroepen kan worden door een andere class, die de dmg parameter heeft
    public void Damage(int damage)
    {
        currentHP -= damage;

        hpBar.sizeDelta = new Vector2(currentHP * 2 ,hpBar.sizeDelta.y);
    }
}
