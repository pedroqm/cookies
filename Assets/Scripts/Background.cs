using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float velocidad;
    Material fondo;

    // Para que se haga correctamente el movimiento del tiled, hay que hacer los siguientes pasos:
    // 1º Crear un material con el sprite con la configuracion: shader =  unlit/transparent 
    // 2º Anadir el sprite a la camara, anadir el script y el material al sprite
    // 3º El sprite debe de tener el wrap mode en repeat,  y el draw mode en tiled

    private void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        if (mr != null)
        {
            fondo = mr.material;
        }
        else
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                fondo = sr.material;
            }
        }
    }
    void Update()
    {
        if (fondo)
        {

            fondo.mainTextureOffset = new Vector2(transform.position.x * velocidad, 0);

        }
    }
}
