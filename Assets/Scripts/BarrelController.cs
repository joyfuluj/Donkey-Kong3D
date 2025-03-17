using System.Collections;
using UnityEngine;

public class DonkeyKongController : MonoBehaviour
{
    public Items barrelScript;
    public Rigidbody rb;
    public SphereCollider coll;
    public Transform player, barrelContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    public bool equipped;
    public static bool slotFull;

    private float timeBetweenActions = 3f; //time delay between picking up and throwing barrel
    private bool canPerformAction = true; //flag to control timing logic

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!equipped)
        {
            barrelScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            barrelScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (canPerformAction)
        {
            //if player is in the range of the barrel and time to pick up has reached
            if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
            {
                PickUp();
                StartCoroutine(PerformActionAfterDelay());
            }
            //For dropping if player is equipped and timer for dropping is reached
            else if (equipped)
            {
                Drop();
                StartCoroutine(PerformActionAfterDelay());
            }
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        // Make barrel a child of the Donkey Kong
        transform.SetParent(barrelContainer);
        
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Making the rigidbody kinematic and the collider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Performing the action on barrels when it is thrown
        barrelScript.enabled = true;
    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.linearVelocity = player.right*dropForwardForce+Vector3.up*dropUpwardForce;

        barrelScript.enabled = false;
    }

    private IEnumerator PerformActionAfterDelay(){
        canPerformAction=false;
        yield return new WaitForSeconds(timeBetweenActions);
        canPerformAction=true;
    }

}
