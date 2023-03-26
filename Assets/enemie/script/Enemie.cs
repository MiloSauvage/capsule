using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public float moveSpeed = 3f; // Vitesse de déplacement de l'ennemi
    public float detectionRadius = 10f; // Rayon de la zone de détection
    public LayerMask detectionLayer; // Les couches à considérer pour la détection
    public GameObject player; // Le joueur à suivre

    public Material angryMaterial;
    public Material originalMaterial; 

    private void Update()
    {
        GetComponent<Renderer>().material = originalMaterial;
        // Vérifier si le joueur est dans la zone de détection
        if (Physics.CheckSphere(transform.position, detectionRadius, detectionLayer))
        {
            // Calculer la direction vers le joueur
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0; // Ignorer la hauteur pour rester sur le sol

            // Faire en sorte que l'ennemi regarde vers le joueur
            transform.LookAt(player.transform);

            // Déplacer l'ennemi vers le joueur
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;

            GetComponent<Renderer>().material = angryMaterial;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dessiner la zone de détection dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}