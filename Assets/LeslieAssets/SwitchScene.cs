using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameStarts;

    public GameObject vacuum;
    public GameObject flashlight;

    private OVRPassthroughLayer passthroughLayer;

    private void Start()
    {
        passthroughLayer = GetComponent<OVRPassthroughLayer>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            startMenu.SetActive(false);
            gameStarts.SetActive(true);
            vacuum.SetActive(true);
            flashlight.SetActive(true);
            SetPassthroughColor();
        }
    }

    private void SetPassthroughColor()
    {
        passthroughLayer.colorMapEditorBrightness = -0.5f;
        passthroughLayer.edgeRenderingEnabled = true;
        passthroughLayer.edgeColor = Color.green;
    }
}
