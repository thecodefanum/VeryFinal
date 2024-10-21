using UnityEngine;
using TMPro;

public class PowerUpHandler : MonoBehaviour
{
    public TextMeshProUGUI immunityText;
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;

    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
                immunityText.gameObject.SetActive(false); // Hide invincibility message
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            ActivateInvincibility(10f); // 10 seconds of invincibility
            Destroy(collision.gameObject); // Destroy the power-up
            Debug.Log("Power-up collected");
        }
        else if (isInvincible && collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject); // Destroy obstacle
            Debug.Log("Obstacle destroyed");
        }
    }

    public void ActivateInvincibility(float duration)
    {
        isInvincible = true;
        invincibilityTimer = duration;
        immunityText.gameObject.SetActive(true); // Show invincibility message
        immunityText.text = "You are invincible for 10 seconds!";
        Debug.Log("Invincibility activated");
    }
}
