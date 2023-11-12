using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{

    public float speed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    public Animator anis;
    public int health=100;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public Enemigo enemigo;
    public int damage =15;
    public int cantPanes = 11;


    private float lastDamageTime;
    public float damageInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput > 0 || verticalInput < 0)
        {
            anis.SetFloat("walk", Mathf.Abs(verticalInput));
            //ControladorSonidos.Instance.EjecutarSonido(pasosSonido);
            //caminar.enabled = true;
        }
        else
        {
            anis.SetFloat("walk", verticalInput);
            //caminar.enabled = false;
        }

        Vector3 movement = transform.forward * speed * verticalInput;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.fixedDeltaTime, 0f);

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Botiquin")
        {
            if (health < 100)
            {
                health += 10;
                Destroy(other.gameObject);
                if (health > 100)
                {
                    health = 100;
                }
            }          
        }

        if (other.tag == "Municion")
        {
            cantPanes = 11;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            // Asegúrate de que haya pasado el tiempo de intervalo antes de aplicar otro daño.
            if (Time.time - lastDamageTime >= damageInterval)
            {
                health -= damage;
                lastDamageTime = Time.time; // Actualiza el tiempo del último daño.

                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }


    //public void takeDamage(int damage)
    //{
    //    health -= damage;

    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);

    //    }
    //}


    public void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && cantPanes>0)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            cantPanes -= 1;
        }
    }
}



