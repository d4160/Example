using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour
{

    public float runspeed = 7.0f;
    public float rotationspeed = 250.0f;
    private Animator animator;

    public float x, y;

    public Rigidbody rb;

    public float FuerzaSaltar = 8f;

    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;
    
    //public int velocidadCorrer;

    public bool conArma;

    public bool estoyGolpeando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;

    void Start()
    {
        puedoSaltar = false;
        conArma = false;
        animator = GetComponent<Animator>();

        velocidadInicial = runspeed;
        velocidadAgachado = runspeed * 0.5f;
    }

    void FixedUpdate()
    {
        if (!estoyGolpeando)
        {
            transform.Rotate(0, x * Time.deltaTime * rotationspeed, 0);
            transform.Translate(0, 0, y * Time.deltaTime * runspeed);

        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {

        /* POR IMPLEMENTAR CORRER AL PERSONAJE
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    velocidadInicial = velocidadCorrer;
                    if (y > 0)
                    {
                        animator.SetBool("correr", true);
                    }
                    else
                    {
                        animator.SetBool("correr", false);
                    }
                }
                else
                {
                    animator.SetBool("correr", false);
                    if(puedoSaltar){
                        velocidadInicial
                    }
                }
        */
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyGolpeando)
        {
            if (conArma)
            {
                animator.SetTrigger("attack");
                estoyGolpeando = true;
            }
            else
            {
                animator.SetTrigger("golpeo");
                estoyGolpeando = true;
            }

        }

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);


        if (puedoSaltar)
        {
            if (!estoyGolpeando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("saltar", true);
                    rb.AddForce(new Vector3(0, FuerzaSaltar, 0), ForceMode.Impulse);
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    animator.SetBool("agachado", true);
                    runspeed = velocidadAgachado;
                }
                else
                {
                    animator.SetBool("agachado", false);
                    runspeed = velocidadInicial;
                }
            }

            animator.SetBool("tocarPiso", true);
        }
        else
        {
            Cayendo();
        }
    }

    public void Cayendo()
    {
        animator.SetBool("tocarPiso", false);
        animator.SetBool("saltar", false);
    }

    public void DejeGolpear()
    {
        estoyGolpeando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejodeAvanzar()
    {
        avanzoSolo = false;
    }
}
