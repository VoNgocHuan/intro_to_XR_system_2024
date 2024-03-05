using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collosionInfo)
    {
        Destroy(gameObject);
    }
}
