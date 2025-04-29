using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
        if (flashlight != null)
        {
            flashlight.enabled = false; // Start with flashlight off
        }
        else
        {
            Debug.LogWarning("No Light component found on the flashlight.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight != null)
            {
                flashlight.enabled = !flashlight.enabled;
            }
        }
    }
}