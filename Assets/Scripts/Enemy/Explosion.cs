using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    int damage = 3;
    float radius = 1.5f;

    void Start()
    {
        Exploid();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

    void Exploid()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

        foreach(Collider colDict in colliders)
        {
            PlayerHealth playerHealth = colDict.GetComponent<PlayerHealth>();
            
            if(!playerHealth) continue;

            playerHealth.PlayerHealthRef(damage);

            break;
        }
    }
}
