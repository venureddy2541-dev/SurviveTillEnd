using UnityEngine;
using System.Collections;

public class StandGun : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform gunHead;
    [SerializeField] Transform gun;
    [SerializeField] GameObject projectile;
    PlayerHealth playerHealth;
    
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(GenProjectile());
    }

    void Update()
    {
        if(!playerHealth) return;

        gun.LookAt(player.position);
    }

    IEnumerator GenProjectile()
    {
        while(playerHealth)
        {
            Projectile newprojectile = Instantiate(projectile,gunHead.position,gun.rotation).GetComponent<Projectile>();
            newprojectile.transform.LookAt(player.position);
            yield return new WaitForSeconds(2f);
        }
    }
}
