using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;
    public float batteryLife = 60f; // Battery duration in seconds
    private float currentBattery;

    void Start()
    {
        flashlight = GetComponent<Light>();
        currentBattery = batteryLife;

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
        if (Input.GetKeyDown(KeyCode.F) && currentBattery > 0)
        {
            if (flashlight != null)
            {
                flashlight.enabled = !flashlight.enabled;
            }
        }

        // Drain battery if flashlight is on
        if (flashlight != null && flashlight.enabled)
        {
            currentBattery -= Time.deltaTime;

            if (currentBattery <= 0)
            {
                currentBattery = 0;
                flashlight.enabled = false;
                Debug.Log("Battery dead");
            }
        }
    }
}