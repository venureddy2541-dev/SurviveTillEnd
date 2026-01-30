using UnityEngine;

public class AmmoAmount : PickUp
{
    [SerializeField] float ammoRotate;

    void Update()
    {
        transform.Rotate(0f,ammoRotate,0f);
    }

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AmmoCollector();
    }
}
