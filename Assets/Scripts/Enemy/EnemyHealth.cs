using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 3;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject deathVFXPos;
    GameManager gameManager;
    int currentHealth;

    void Awake()
    {
        currentHealth = enemyHealth;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Start()
    {
        gameManager.EnemyText(1);
    }

    public void EnemyDamage(int damageRef)
    {
        currentHealth -= damageRef;
        if(currentHealth <= 0)
        {
            SelfDistruct();
        }
    }

    public void SelfDistruct()
    {
        gameManager.EnemyText(-1);
        Instantiate(deathVFX,deathVFXPos.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
