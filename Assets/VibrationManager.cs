using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //haptic tutorial www.youtube.com/watch?v=9KJqZBoc8m4 
    public void vacuumVibration(AudioClip vacuumOpen, OVRInput.Controller controller)
    {

        OVRHapticsClip clip = new OVRHapticsClip(vacuumOpen);

        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
    }

  /*  public void flashVibration(AudioClip flashlight_click, OVRInput.Controller controller)
    {

        OVRHapticsClip clip = new OVRHapticsClip(flashlight_click);

        if (controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
    }*/
}
