using UnityEngine;
using UnityEngine.UI;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;
    public Slider batterySlider;
    public float batteryMax = 100f;
    private float batteryCurrent;
    public float batteryDrainRate = 10f;
    public void RechargeBattery()
{
    batteryCurrent = batteryMax;
}

    void Start()
    {
        flashlight = GetComponent<Light>();
        batteryCurrent = batteryMax;
        if (flashlight != null) flashlight.enabled = false;

        // Initialize slider
        if (batterySlider != null)
        {
            batterySlider.maxValue = batteryMax;
            batterySlider.value = batteryCurrent;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && batteryCurrent > 0)
        {
            flashlight.enabled = !flashlight.enabled;
        }

        if (flashlight.enabled)
        {
            batteryCurrent -= batteryDrainRate * Time.deltaTime;
            batteryCurrent = Mathf.Max(batteryCurrent, 0f);

            if (batteryCurrent <= 0)
            {
                flashlight.enabled = false;
            }
        }

        if (batterySlider != null)
        {
            batterySlider.value = batteryCurrent;
        }
    }
}