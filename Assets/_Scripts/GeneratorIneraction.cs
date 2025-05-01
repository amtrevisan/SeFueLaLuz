using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    public GameObject winMessageUI; // Optional win message
    public Light[] lightsToActivate; // Add lights here in Inspector
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            TryActivateGenerator();
        }
    }

    void TryActivateGenerator()
    {
        PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
        if (inventory != null && inventory.HasAllItems())
        {
            Debug.Log("Generator activated! You win!");
            if (winMessageUI != null) winMessageUI.SetActive(true);

            // Turn on the lights
            foreach (Light l in lightsToActivate)
            {
                l.enabled = true;
            }
        }
        else
        {
            Debug.Log("You don't have all the items.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}