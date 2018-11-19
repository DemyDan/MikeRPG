using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    PlayerController hero;
    Animator anim;

    public float maxHP;
    private float currentHP;
    public int damage;
    public RectTransform hpBar;
    public float secondsBetweenShots;
    public float hpBarSize;
    public float viewRange = 5;
    public float attackRange = 2;
    public bool canAttack = false;
    public Rigidbody item;

    private float timestamp;
    private Transform player;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;

        //Initialize the hp
        currentHP = maxHP;
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
            if (distance <= viewRange && distance >= attackRange && agent)
            {
                agent.SetDestination(player.position);
                anim.SetFloat("Walk", 2);
            }
            else if(distance <= attackRange && agent)
            {
                transform.LookAt(playerPosition);
                anim.SetFloat("Walk", 0);
                if (Time.time >= timestamp)
                {
                    Attack();
                }
            }
            else if (distance >= viewRange && agent)
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
        anim.SetTrigger("Attack"); 

        timestamp = Time.time + secondsBetweenShots;
    }

    //Ga weg als de hp aan 0 is of eronder
    void Dead()
    {
        if(currentHP <= 0)
        {
            Destroy(gameObject);
            Rigidbody itemDrop = Instantiate(item, transform.position, transform.rotation);
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
