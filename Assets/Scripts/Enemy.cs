using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    PlayerController hero;

    public float maxHP;
    private float currentHP;
    public int damage;
    public RectTransform hpBar;
    public float secondsBetweenShots;
    public float hpBarSize;

    public bool canAttack = false;
    private float timestamp;
    private Transform player;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        currentHP = maxHP;

        //Initialize the hp Bar
        float hpBarSize = (currentHP / maxHP) * 100;
        hpBar.sizeDelta = new Vector2(hpBarSize * 2, hpBar.sizeDelta.y);
        
        //Position for the enemy to return too if the player distance is too far
        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        Dead();
        FollowHero();
    }

    void FollowHero()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        //Postie van de player voor als de enemy ernaar moet draaien
        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

        //Bij welke distance moet wat gebeuren
        if(player != null)
        {
            if (distance <= 5 && distance >= 2 && agent)
            {
                agent.SetDestination(player.position);
            }
            else if(distance <= 2 && agent)
            {
                transform.LookAt(playerPosition);

                if (Time.time >= timestamp)
                {
                    Attack();
                }
            }
            else if (distance >= 5 && agent)
            {
                agent.SetDestination(originalPos);
            }
        }
    }

    //Damage de hero en reset de reload
    void Attack()
    {
           hero = player.GetComponent<PlayerController>();
           hero.Damage(damage);

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

        hpBarSize = (currentHP / maxHP) * 100;

        hpBar.sizeDelta = new Vector2(hpBarSize * 2,hpBar.sizeDelta.y);
        //Debug.Log(currentHP + " currentHP / " + maxHP + " MaxHP = " + currentHP/maxHP + " * 100 = " + hpBarSize);
    }
}
