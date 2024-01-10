using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePrueba : MonoBehaviour
{
    public int vidasPersonaje = 5; 
    public int vidasPersonaje2 = 3;

    public float numeroDecimal = 4.5f;

    public string nombrePersonaje = "Nombre de nuestro personaje";

    private bool interruptor = false;



    // Start is called before the first frame update
    void Start()
    {
        vidasPersonaje = 10;
        numeroDecimal = 7.54f;
        nombrePersonaje = "digrefg";
        interruptor = true;

        int suma = vidasPersonaje + vidasPersonaje2;
        Debug.Log(suma);
        string summaTextos = nombrePersonaje + "hula";



        Debug.Log(summaTextos);
        Debug.Log(nombrePersonaje);
        Debug.Log(vidasPersonaje);
        Debug.Log(numeroDecimal);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
