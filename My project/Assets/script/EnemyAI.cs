using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int hitThreshold = 3; // Number of hits required to deactivate the AI
    public float deactivationTime = 5f; // Time before the ragdoll disappears

    private int currentHits = 0;
    private bool isDeactivated = false;

    public AudioSource hitSound;
    public GameObject ragdollPrefab;

    private void Start()
    {
        if (hitSound == null)
        {
            Debug.LogError("Hit sound is not assigned to the script!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDeactivated) return;

        // Check if the colliding object has the "hit" tag
        if (collision.gameObject.CompareTag("hit"))
        {
            // Destroy the bullet on collision
            Destroy(collision.gameObject);

            // Increment the hit count
            currentHits++;

            // Play hit sound
            hitSound.Play();

            // Check if the hit threshold is reached
            if (currentHits >= hitThreshold)
            {
                // Deactivate the AI
                DeactivateAI();
            }
        }
    }

    private void DeactivateAI()
    {
        isDeactivated = true;

        // Play deactivation sound
        // Add your deactivation sound logic here

        // Instantiate ragdoll
        GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
        Destroy(ragdoll, deactivationTime);

        // Disable the original AI
        gameObject.SetActive(false);
    }
}
