using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 10f;
    [SerializeField] int playerDamage = 2;
    [SerializeField] GameObject projectileDeathParticel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ProjectTileMovement();
    }

    void ProjectTileMovement()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.PlayerHealthRef(playerDamage);
        Instantiate(projectileDeathParticel,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
