using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à instancier
    public Transform spawnPoint; // Le point où l'ennemi doit apparaître
    public LayerMask playerLayer; // Le layer du joueur

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
