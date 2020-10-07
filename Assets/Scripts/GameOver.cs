using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Reintentar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
