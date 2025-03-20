using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    public float speed;
    public int scoreValue = 10;
    public float scaleMultiplier = 2.5f;
    public UnityEvent OnItemCollected = new UnityEvent();
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Mario"))
        {
            OnItemCollected.Invoke();
            other.transform.localScale *= scaleMultiplier;
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
