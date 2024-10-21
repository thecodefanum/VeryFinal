using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject tryAgainButton;

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Hide Game Over text at start
        tryAgainButton.SetActive(false); // Hide Try Again button at start
    }

    public void TriggerGameOver()
    {
        gameOverText.gameObject.SetActive(true); // Show Game Over text
        tryAgainButton.SetActive(true); // Show Try Again button
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
