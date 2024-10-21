using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    //public TextMeshProGUI gameOverText;
    private ScoreManager _scoreManager;
    private GameOverManager gameOverManager;

    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }


    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin"))
        {
            _scoreManager.AddScore(1);
            Destroy(other.gameObject);
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
           // gameOverText.gameObject.SetActive(true);
            gameOver = true;
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverManager.TriggerGameOver();

        } 
    }
}

