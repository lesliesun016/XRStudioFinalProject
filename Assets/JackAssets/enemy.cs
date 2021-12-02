using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    bool isSlow = false;
    GameObject myTarget;
    Transform targetPos;
    float mySpeed;
    float normalSpeed;
    float slowSpeed;
    private float healthPoint;
    public bool FlashStatus;
    //bool isActivated;

    //ParticleSystem particleAccess;
    // Start is called before the first frame update
    void Start()
    {
       myTarget = GameObject.FindWithTag("MainCamera");
        targetPos = myTarget.transform;
        mySpeed = 1f;
        normalSpeed = 1f;
        slowSpeed = 0.1f;
        healthPoint = 70f;
       // isActivated = gameObject.transform.GetChild(0).gameObject.SetActive(true);
      // isActivated = GetComponent<ParticleSystem>().emission.enabled;
       // isActivated = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //access the flashOn variable from interaction test script for if flashlight is on
        FlashStatus = GameObject.Find("RightHand Controller").GetComponent<InteractionTest>().flashOn;
        Debug.Log("FlashStatus: " + FlashStatus);
       // Debug.Log(hp);
        if (myTarget)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.LookAt(myTarget.transform.position);
            //transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, mySpeed * Time.deltaTime);
            if (transform.position == targetPos.position | healthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }

        if(FlashStatus == false)
        {
            isSlow = true;
            mySpeed = normalSpeed;
        }
     //   Debug.Log(healthPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "light" && FlashStatus == true)
        {
          
            isSlow = true;
            mySpeed = slowSpeed;

        }

        if (other.gameObject.tag == "GameController")
        {
            healthPoint -= 1;
            GetComponent<MeshRenderer>().material.color = Color.green;
           // isActivated = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(FlashStatus == true)
        {
            isSlow = false;
            mySpeed = slowSpeed;
        }
        if (other.gameObject.tag == "GameController")
        {
            healthPoint -= 1;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "light")
        {
            if (FlashStatus == true)
            isSlow = false;
            mySpeed = normalSpeed;

        }

        if (other.gameObject.tag == "GameController")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            //isActivated = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


}
