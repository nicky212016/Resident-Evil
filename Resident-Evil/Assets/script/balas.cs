using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public int damage = 25;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Enemigo enemigo = collision.GetComponent<Enemigo>();

        if (enemigo != null)
        {
            enemigo.takeDamage(damage);

        }

        Destroy(gameObject);
    }
}