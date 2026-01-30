using UnityEngine;

public class WeaponGeneratorScript : MonoBehaviour
{
    [SerializeField] float weaponRotateSpeed;
    [SerializeField] GameObject[] weaponPrefab;

    void Start()
    {
        WeaponGeneratorTimer();
    }

    void Update()
    {
        transform.Rotate(0f,weaponRotateSpeed,0f);
    }

    public void WeaponGenerator()
    {
        Invoke("WeaponGeneratorTimer",5);
    }

    void WeaponGeneratorTimer()
    {
        int randomWeaponIndex = Random.Range(0,weaponPrefab.Length);
        Instantiate(weaponPrefab[randomWeaponIndex],transform.position,Quaternion.identity,transform);
    }
}
