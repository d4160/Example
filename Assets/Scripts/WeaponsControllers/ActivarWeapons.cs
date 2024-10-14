using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarWeapons : MonoBehaviour
{
    public CogerWeapons cogerWeapons;
    public int numeroWeapons;

    // Start is called before the first frame update
    void Start()
    {
        cogerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<CogerWeapons>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            cogerWeapons.ActivarWeapons(numeroWeapons);
            Destroy(gameObject); // Destruimos el objeto cuando se activa la caja con las armas.
        }
    }

}
