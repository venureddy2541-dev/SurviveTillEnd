using UnityEngine;
using TMPro;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] int enemyInstPer = 5;
    [SerializeField] GameObject robotParent;
    PlayerHealth playerHealth;
    
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        InvokeRepeating("RobotGenerator",0f,enemyInstPer);
    }

    void RobotGenerator()
    {
        if(!playerHealth) return;
        Instantiate(Enemy,transform.position,Quaternion.identity,robotParent.transform);
    }

}
