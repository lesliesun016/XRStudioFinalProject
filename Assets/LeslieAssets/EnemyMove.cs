using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public Light spotlight;

    //Audio
    public AudioSource ghost;
    public AudioClip ghost_normal;
    public AudioClip ghost_lit;

    private float speed = 1f;
    private bool collide;

    private bool litOn;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spotlight = GameObject.FindWithTag("GameController").GetComponent<Light>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!ghost.isPlaying)
        {
            litOn = false;
            ghost.PlayOneShot(ghost_normal);
        }

        if (collide && spotlight.enabled)
        {
            gameObject.isStatic = true;

            if (!litOn)
            {
                ghost.Stop();
                ghost.PlayOneShot(ghost_lit);
                litOn = true;
            }
            
        }
        else
        {
            gameObject.isStatic = false;
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.LookAt(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);           
        }

        if (transform.position == target.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flashlight")
        {
            collide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Flashlight")
        {
            collide = false;
        }
    }
}
