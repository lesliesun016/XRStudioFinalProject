using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public OVRInput.Controller vacuum;
    public OVRInput.Button button = OVRInput.Button.One;
    public float speed = 0.2f;
    public GameObject particleSystem;
    public Animator vacuumAnimator;

    public AudioSource vacuumAudioSource;
    public AudioSource ghostAudioSource;
    public AudioClip vacuumOpen;
    public AudioClip vacuumClose;
    public AudioClip ghostVacuumed;
    
    private bool collide;
    private GameObject enemy;
    private bool vacuumLast;
    private bool vacOn;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!ghostAudioSource) vacOn = false;
       if (OVRInput.Get(button, vacuum))
        {
            OVRInput.SetControllerVibration(0.3f, 0.3f, vacuum);
            if (!vacuumAudioSource.isPlaying) vacuumAudioSource.PlayOneShot(vacuumOpen);
            particleSystem.SetActive(true);
            if (collide)
            {
                enemy.transform.localScale -= new Vector3(speed, speed, speed);
               // enemy.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, speed * Time.deltaTime);
                if (!vacOn)
                {
                    ghostAudioSource.Stop();
                    ghostAudioSource.PlayOneShot(ghostVacuumed);
                    vacOn = true;
                }
                if (enemy.transform.localScale == new Vector3(0, 0, 0))
                {
                    OVRInput.SetControllerVibration(1, 1, vacuum);
                    Destroy(enemy);
                    vacuumAnimator.Play("vacuumAnimation");
                }
            }
            vacuumLast = true;
        } else
        {
            vacuumAnimator.Play("Static");
            OVRInput.SetControllerVibration(0, 0, vacuum);
            if (OVRInput.Get(button, vacuum) != vacuumLast)
            {
                vacuumAudioSource.Stop();
                vacuumAudioSource.PlayOneShot(vacuumClose);
            }
            vacuumLast = false;
            particleSystem.SetActive(false);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            collide = true;
            enemy = other.gameObject;
            ghostAudioSource = other.GetComponent<AudioSource>();
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
