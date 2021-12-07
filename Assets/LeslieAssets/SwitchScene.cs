using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public GameObject gameStarts;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            gameStarts.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
