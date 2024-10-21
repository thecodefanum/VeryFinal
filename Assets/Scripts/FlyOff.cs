using UnityEngine;

public class FlyOff : MonoBehaviour
{
    public float forceMagnitude = 10f; // Adjust the force as needed

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Ensure obstacle is tagged correctly
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = transform.position - collision.transform.position;
                forceDirection.y = 1; // Ensure force is applied upwards
                Debug.Log("Force Direction: " + forceDirection); // Debugging line
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                Debug.Log("Force Applied!"); // Debugging line
            }
        }
    }
}
