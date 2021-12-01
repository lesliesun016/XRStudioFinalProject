using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public OVRInput.Controller vacuum;
    public OVRInput.Controller flashlight;
    public OVRInput.Button vacuumButton;
    public OVRInput.Button flashlightButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(flashlightButton, flashlight))
        {

        }
    }
}
