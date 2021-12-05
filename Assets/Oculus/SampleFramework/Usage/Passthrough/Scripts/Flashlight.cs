using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject lightVolume;
    public Light spotlight;
    public GameObject bulbGlow;
    public AudioSource flashlightSound;

    private bool lightSound;

    void LateUpdate()
    {
        // ensure all the light volume quads are camera-facing
        for (int i = 0; i < lightVolume.transform.childCount; i++)
        {
            lightVolume.transform.GetChild(i).rotation = Quaternion.LookRotation((lightVolume.transform.GetChild(i).position - Camera.main.transform.position).normalized);
        }

        if (!lightSound && spotlight.enabled)
        {
            lightSound = true;
            flashlightSound.playOnAwake = true;
            flashlightSound.PlayOneShot(flashlightSound.clip);
        } else if (!spotlight.enabled)
        {
            lightSound = false;
        }
    }

    public void ToggleFlashlight()
    {
        lightVolume.SetActive(!lightVolume.activeSelf);
        spotlight.enabled = !spotlight.enabled;
        bulbGlow.SetActive(lightVolume.activeSelf);
    }

    public void EnableFlashlight(bool doEnable)
    {
        lightVolume.SetActive(doEnable);
        spotlight.enabled = doEnable;
        bulbGlow.SetActive(doEnable);
    }
}
