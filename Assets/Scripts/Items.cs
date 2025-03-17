using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}