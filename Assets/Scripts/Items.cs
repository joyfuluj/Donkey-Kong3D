using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Items : MonoBehaviour
{
    public float speed;
    public int scoreValue = 10;
    public float itemScaleMultiplier = 0.5f;
    public float playerScaleMultiplier = 2.5f;
    public float scaleDuration = 2f; // Time taken to scale the player
    public UnityEvent OnItemCollected;

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];

            // Check if the player hit the bottom of the cube
        if (Vector3.Dot(contact.normal, Vector3.up) > 0.9f)  // Normal is pointing upwards
        {
                Debug.Log("Player collided with the bottom of the cube!");
            if (other.gameObject.CompareTag("Mario"))
            {
                OnItemCollected?.Invoke();

                Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation; 
                }

                StartCoroutine(ScalePlayerOverTime(other.transform, playerRb, scaleDuration, playerScaleMultiplier, itemScaleMultiplier));
            }
        }
    }

    private IEnumerator ScalePlayerOverTime(Transform player, Rigidbody playerRb, float duration, float playerScale, float itemScale)
    {
        
        Debug.Log("Started scaling...");
        Vector3 playerStartScale = player.localScale;
        Vector3 playerEndScale = playerStartScale * playerScale;
        Vector3 itemStartScale = transform.localScale;
        Vector3 itemEndScale = itemStartScale * itemScale;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            player.localScale = Vector3.Lerp(playerStartScale, playerEndScale, elapsed / duration);
            transform.localScale = Vector3.Lerp(itemStartScale, itemEndScale, elapsed / duration);
            Debug.Log("Current Size: " + player.localScale.ToString());
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.localScale = playerEndScale;
        Debug.Log("Fianl Scale: " + player.localScale.ToString());
        Destroy(gameObject); // Destroy the item after collision


        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints.None;
            playerRb.constraints = RigidbodyConstraints.FreezeRotation; // Keep rotation frozen
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
