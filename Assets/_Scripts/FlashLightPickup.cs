using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject playerFlashlight;  // Flashlight attached to player
    public GameObject instructionUI;     // UI Panel with instructions
    public GameObject objectToDisable;   // FlashlightProp
    private bool isPlayerNear = false;
    private bool hasPickedUp = false;
    private bool instructionsShown = false;

    void Update()
    {
        if (!hasPickedUp && isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            // First press: pick up flashlight and show instructions
            if (playerFlashlight != null)
                playerFlashlight.SetActive(true);

            if (instructionUI != null)
                instructionUI.SetActive(true);

            if (objectToDisable != null)
                objectToDisable.SetActive(false);

            hasPickedUp = true;
            instructionsShown = true;
        }
        else if (instructionsShown && Input.GetKeyDown(KeyCode.E))
        {
            // Second press: hide instructions
            if (instructionUI != null)
            {
                Debug.Log("HidingUI");
                instructionUI.SetActive(false);
            }

            instructionsShown = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}