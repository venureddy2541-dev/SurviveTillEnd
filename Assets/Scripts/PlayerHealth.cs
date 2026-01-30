using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCam;
    [SerializeField] Image[] shieldBar;
    [SerializeField] GameObject gameOverObject;
    [SerializeField] GameObject cursorObject;
    [SerializeField] GameObject zoomImage;
    int deathVCPriority = 20;
    int currentHealth;
    int currentIndex;
    

    void Start()
    {
        currentIndex = shieldBar.Length - 1;
        currentHealth = health;
    }

    public void PlayerHealthRef(int healthRef)
    {
        currentHealth -= healthRef;

        if(currentHealth <= 0)
        {
            PlayerDeadState();
        }

        for(int i = currentIndex;i>=currentHealth;i--)
        {
            if(i<0) break;
            shieldBar[i].enabled = false;
        }
        currentIndex -= healthRef;
    }

    void PlayerDeadState()
    {
        weaponCam.parent = null;
        deathVirtualCamera.Priority = deathVCPriority;
        gameOverObject.SetActive(true);
        cursorObject.SetActive(false);
        zoomImage.SetActive(false);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }
}
