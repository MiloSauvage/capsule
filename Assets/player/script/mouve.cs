using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouve : MonoBehaviour
{

    public float vitesse = 5.0f;


    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;
        float deplacementVertical = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        transform.Translate(deplacementHorizontal, 0, deplacementVertical);

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * vitesse * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * vitesse * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * vitesse * Time.deltaTime);
        }
    
    }
}
