using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererCollisionTrigger : MonoBehaviour
{
    Wander wanderComponentOfParent;

    void Start()
    {
        wanderComponentOfParent = transform.parent.gameObject.GetComponent<Wander>();
    }

    void OnTriggerEnter(Collider collider)
    //void OnCollisionEnter( Collision collision )
    {
        Debug.Log("colliding with something");
        wanderComponentOfParent.NewHeadingRoutine();
    }
}