using UnityEngine;

public class WeaponSOPickUp : PickUp
{  
    [SerializeField] WeaponSO weaponSO;
    WeaponGeneratorScript weaponGeneratorScript;

    void Start()
    {                
        weaponGeneratorScript = GetComponentInParent<WeaponGeneratorScript>();
    }
          
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {       
        activeWeapon.SwitchWeapon(weaponSO);
        weaponGeneratorScript.WeaponGenerator();
    }
}
