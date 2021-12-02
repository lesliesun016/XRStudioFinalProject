using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public OVRInput.Controller vacuum;
    public OVRInput.Button button = OVRInput.Button.One;
    public float speed = 0.2f;
    public GameObject particleSystem;

    private bool collide;
    private GameObject enemy;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.Get(button, vacuum))
        {
            particleSystem.SetActive(true);
            if (collide)
            {
                enemy.transform.localScale -= new Vector3(speed, speed, speed);
                if (enemy.transform.localScale == new Vector3(0, 0, 0))
                {
                    Destroy(enemy);
                }
            }
        } else
        {
            particleSystem.SetActive(false);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            collide = true;
            enemy = other.gameObject;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            collide = false;
            enemy = null;
        }
    }
}
