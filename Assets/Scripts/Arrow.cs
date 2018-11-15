using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public int damage;

    public float timer;


    void update()
    {
        timer += 1.0F * Time.deltaTime;

        if (timer >= 10)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Damage(damage);
            GameObject.Destroy(gameObject);
        }
    }
}
