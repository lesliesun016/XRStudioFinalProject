using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemy : MonoBehaviour
{
    public Light spotlight;

    private GameObject enemy;
    private bool collide;
    private Rigidbody enemyRigidbody;
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (collide && spotlight.enabled)
        {
            enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            //enemy.isStatic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            enemy = other.gameObject;
            enemyRigidbody = enemy.transform.GetComponent<Rigidbody>();
            collide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            enemyRigidbody.constraints = RigidbodyConstraints.None;
            enemy.isStatic = false;
            collide = false;
        }
    }
}
