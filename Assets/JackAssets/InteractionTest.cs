using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class InteractionTest : MonoBehaviour
{
    public GameObject CubeObject;
    public GameObject Flashlight;
    public bool flashOn;
    [SerializeField] ActionBasedController actionBasedController;

    /*void OnEnable()
    {
        actionBasedController.selectAction.action.performed += ActionPerformed;
        actionBasedController.rotationAction.action.performed += RotationActionPerformed;

    }*/
    void Start()
    {
        // Flashlight.GetComponent<Light>().intensity = 0;
        Flashlight.GetComponent<Light>().enabled = false;
        //Flashlight.GetComponent<CapsuleCollider>().enabled = false;
        flashOn = false;

        actionBasedController.selectAction.action.performed += ActionPerformed;
        actionBasedController.selectAction.action.canceled += ActionCancelled;
        actionBasedController.rotationAction.action.performed += RotationActionPerformed;

    }

    private void ActionCancelled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        Debug.Log("select action has been cancelled");
        // CubeObject.GetComponent<Renderer>().material.color = Color.red;
        // Flashlight.GetComponent<Light>().intensity = 0;
        Flashlight.GetComponent<Light>().enabled = false;
        flashOn = false;
       // Flashlight.GetComponent<CapsuleCollider>().enabled = false;
    }

    private void ActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
      
        Debug.Log("select action has been performed");
        // CubeObject.GetComponent<Renderer>().material.color = Color.green;
        ///////
        // Flashlight.GetComponent<Light>().intensity = 20;
        Flashlight.GetComponent<Light>().enabled = true;
        flashOn = true;
        //Flashlight.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void RotationActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

       // Debug.Log("rotate action has been performed");
    }

    /*private void OnDisable()
    {
        actionBasedController.selectAction.action.performed -= ActionPerformed;
        actionBasedController.selectAction.action.performed -= RotationActionPerformed;
    }*/

    void Update()
    {
        Debug.Log("FlashOn:         " + flashOn);
    }
}
