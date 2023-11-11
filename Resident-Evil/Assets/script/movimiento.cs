using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{


    public float speed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    public Animator anis;

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
}