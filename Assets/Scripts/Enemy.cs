using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public const int maxHP = 100;
    public int currentHP = maxHP;

    public RectTransform hpBar;

    private float hpBarSize;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Dead();
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
