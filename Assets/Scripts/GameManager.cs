using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] TMP_Text enemyText;
    [SerializeField] GameObject winText;
    int enemyCounter;

    public void OnRestart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnPlay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void EnemyText(int noOfEnemies)
    {
        enemyCounter += noOfEnemies;
        enemyText.text = "ENEMY_COUNT : " + enemyCounter.ToString();
        if(enemyCounter <= 0)
        {
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            winText.SetActive(true);
        }
    }
}
