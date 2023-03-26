using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la balle à tirer
    public Transform shootingPoint; // Point d'origine du tir
    public float shootingDistance = 100f; // Distance maximale du tir
    public LayerMask shootableLayers; // Les couches à toucher avec le tir
    public Camera myCamera; // La caméra à utiliser pour créer le rayon

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
    // Obtenir la position de la souris dans le monde
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = myCamera.nearClipPlane;
        Vector3 mouseWorldPosition = myCamera.ScreenToWorldPoint(mousePosition);

        // Créer un vecteur directionnel qui pointe de la position de la souris à la position de tir
        Vector3 shootingDirection = shootingPoint.position - mouseWorldPosition;

        // Créer un rayon partant du point de tir dans la direction opposée de la souris
        Ray ray = new Ray(shootingPoint.position, shootingDirection);

        Debug.DrawLine(shootingPoint.position, shootingPoint.position - shootingDirection * shootingDistance, Color.red, 0.1f);

        // Vérifier si le rayon touche quelque chose dans la couche shootableLayers
        if (Physics.Raycast(ray, out RaycastHit hit, shootingDistance, shootableLayers))
        {
            // Récupérer la position de l'impact
            Vector3 hitPosition = hit.point;

            // Créer la balle à partir du prefab
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            // Faire en sorte que la balle regarde vers l'impact
            bullet.transform.LookAt(hitPosition);

            // Donner une vitesse à la balle pour qu'elle avance vers l'impact
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50f;

            // Détruire la balle après 2 secondes pour éviter les fuites de mémoire
            Destroy(bullet, 2f);
        }
    }
}
