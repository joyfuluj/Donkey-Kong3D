using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            onPlayerEnter(collider.gameObject.GetComponent<PlayerController>());
        }
    
    }
    public void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            onPlayerExit(collider.gameObject.GetComponent<PlayerController>());
        }
    }
    public onPlayerEnter(PlayerController player){
        player.canClimb(true);
    }
    public onPlayerExit(PlayerController player){
        player.canClimb(false);
    }
}
