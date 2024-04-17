using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esto sale en el examen, todo el script, este script es para hacer que al apretar un boton todos los enemigos de la pantalla mueran
public class GameManager : MonoBehaviour
{
    
    public List<GameObject> enemiesInScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            DestroyEnemiesInScreen();
        }
    }


    public void DestroyEnemiesInScreen()
    {
        foreach (GameObject enemy in enemiesInScreen)
        {
            Destroy(enemy);
        }
    }
}
