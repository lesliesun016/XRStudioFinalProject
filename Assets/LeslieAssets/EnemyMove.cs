using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public OVRInput.Controller vacuum;
    public OVRInput.Button button = OVRInput.Button.One;
    public Transform target;
    public Light spotlight;

    //Audio
    public AudioSource ghost;
    public AudioClip ghost_normal;
    public AudioClip ghost_lit;

    public Renderer ghostRender;

    private float speed = 2f;
    private float normalSpeed = 2f;
    private float slowSpeed = 0.2f;
    private bool collide;

    private bool litOn;
    
    private Color emissionColor;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spotlight = GameObject.FindWithTag("GameController").GetComponent<Light>();
        emissionColor = ghostRender.material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.LookAt(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (!ghost.isPlaying)
        {
            ghost.PlayOneShot(ghost_normal);
        }

        if (collide && spotlight.enabled)
        {

            if (OVRInput.Get(button, vacuum) )
            {
                speed = normalSpeed;
            } else
            {
                //gameObject.isStatic = true;
                speed = slowSpeed;
            }
            ghostRender.material.SetColor("_Color", Color.white);
            ghostRender.material.SetColor("_EmissionColor", emissionColor * 2);
            

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
            speed = normalSpeed;
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.LookAt(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            ghostRender.material.SetColor("_Color", Color.black);
            ghostRender.material.SetColor("_EmissionColor", emissionColor * -2);
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
            litOn = false;
        }
    }
}
