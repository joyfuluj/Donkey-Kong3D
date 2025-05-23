using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    public float speed;
    public int scoreValue = 10;
    public UnityEvent OnCoinCollected = new UnityEvent();
    public ParticleSystem collectedCoin;

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        // Debug.Log("Rotation: " + transform.rotation.eulerAngles);
    }
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Mario"))
        {
            // end after 2 seconds
            ParticleSystem k =Instantiate(collectedCoin, transform.position, Quaternion.identity);
            Destroy(k, 2f);
            if(AudioManager.instance != null)
            {

                AudioManager.instance.sfxSource.PlayOneShot(AudioManager.instance.getCoinClip);
            }
            OnCoinCollected.Invoke();
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }
}

