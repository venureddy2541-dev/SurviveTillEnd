using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO",menuName = "Scriptable Object/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public GameObject HitVFx;
    public int Damage;
    public float ShootRate;
    public bool isAutomatic;
    public float speedAfterZoom; 
    public float zoomDistance;
    public int MagzineSize;
}
