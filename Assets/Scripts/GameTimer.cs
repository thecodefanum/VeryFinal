using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public float timeRemaining = 30f;
    private bool timerIsRunning = false;
    private AudioSource audioSource;
    public AudioClip beepSound; // Sound to play when time is up

    void Start()
    {
        timerIsRunning = true;
        audioSource = GetComponent<AudioSource>();
        gameOverText.gameObject.SetActive(false); // Ensure the game over text is hidden at the start

        // Null check for timerText
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned.");
            return;
        }

        // Null check for gameOverText
        if (gameOverText == null)
        {
            Debug.LogError("Game Over Text is not assigned.");
            return;
        }

        // Null check for audioSource
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing.");
            return;
        }

        // Null check for beepSound
        if (beepSound == null)
        {
            Debug.LogError("Beep Sound is not assigned.");
            return;
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                TimeUp();
            }
        }
    }

    void UpdateTimerText(float timeToDisplay)
    {
        timeToDisplay += 1; // Add 1 second for a smoother countdown
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeUp()
    {
        gameOverText.gameObject.SetActive(true); // Show "Time is up" message
        gameOverText.text = "Time is up!";
        PlayBeepSound();
        Time.timeScale = 0f; // Stop the game
    }

    void PlayBeepSound()
    {
        if (audioSource != null && beepSound != null)
        {
            Debug.Log("Playing beep sound.");
            audioSource.PlayOneShot(beepSound);
        }
    }
}
