using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fires : MonoBehaviour
{
    //Two int's to keep track of the the amounts the fire has been hit and what its treshold is
    [SerializeField]
    private int hitTreshold = 20;
    private int amountsHit = 0;

    private FiresManager firesManager;
    private GameObject fireManagerObject;

    //Finds the fireManager every time the fire prefab is instantiate
    private void Start()
    {
        fireManagerObject = GameObject.FindGameObjectWithTag("FireManager");
        firesManager = fireManagerObject.GetComponent<FiresManager>();
    }

    //OnCollisonEnter that checks if anything hits the collider as it needs to be hit 20 times for the fire to be extinguished
    //there is no need to specify with what it collided
    private void OnCollisionEnter(Collision collision)
    {
        //Increases the AmountsHit integer each time the collider is triggerd
        amountsHit++;
        //Debug.Log(amountsHit);
        //This if statement checks if the fire has been hit and has reached the HitTreshold and needs to be extinguished if so it starts the coroutine and resets the timeleft also disables the visual components
        if (amountsHit == hitTreshold)
        {
            StartCoroutine(KillTheFire());
            firesManager.timeLeft = 60;

            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //IEnumerator that  makes sure that a new fire spawns after 10 seconds so that a new fire doesn't spawn right away
    //Also executes DeleteFire() at the end to make sure the gameobject is deleted
    IEnumerator KillTheFire()
    {
        yield return new WaitForSeconds(10);
        firesManager.StartNewFires();

        yield return new WaitForSeconds(5);
        DeleteFire();
    }

    //Deletes the gameobject
    void DeleteFire()
    {
        Destroy(gameObject);
    }

}
