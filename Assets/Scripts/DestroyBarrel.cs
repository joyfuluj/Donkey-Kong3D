using UnityEngine;

public class DestroyBarrel : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Barrel")){
            Debug.Log("Destorying barrel");
            Destroy(collision.gameObject);
        }
    }
}
