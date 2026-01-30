using UnityEngine;

public abstract class PickUp : MonoBehaviour
{ 
    const string Player = "Player";
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Player))
        { 
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();             
            OnPickup(activeWeapon);           
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}