using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    public float speed;
    public int scoreValue = 10;
    public UnityEvent OnCoinCollected = new UnityEvent();
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCoinCollected.Invoke();
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}

