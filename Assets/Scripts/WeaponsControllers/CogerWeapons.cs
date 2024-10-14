using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerWeapons : MonoBehaviour
{

    public knightController kinaController;
    public GameObject[] armas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DesactivarTodosLosArmas();
        }
    }

    public void ActivarWeapons(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);

        //animación de activacion de armas
        kinaController.conArma = true;
    }

    public void DesactivarTodosLosArmas()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        //animacion de desactivacion de armas
        kinaController.conArma = false;
    }
}
