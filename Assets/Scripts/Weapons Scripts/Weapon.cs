using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{ 
    [SerializeField] ParticleSystem mazelFlash;
    [SerializeField] LayerMask layerMask;
    CinemachineImpulseSource impulseSource;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shooting(WeaponSO weaponSO)
    {
        RaycastHit Hit;
        impulseSource.GenerateImpulse();
        mazelFlash.Play();

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out Hit,Mathf.Infinity,layerMask,QueryTriggerInteraction.Ignore))
        {
            
            Instantiate(weaponSO.HitVFx,Hit.point,Quaternion.identity);
            EnemyHealth enemyHealth = Hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.EnemyDamage(weaponSO.Damage);

        }
    }
}
