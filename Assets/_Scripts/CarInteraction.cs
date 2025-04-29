using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [Header("Car Settings")]
    public int CarID; // now manually set in Inspector
    public bool hasItem = false;

    [Header("UI & Interaction")]
    public GameObject mapMarker; // Assigned by GameManager
    public GameObject interactionPrompt;

    private bool isPlayerNear = false;

    void Awake()
    {
        // Removed auto-ID assignment
    }

    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        if (hasItem)
        {
            Debug.Log($"You found an item in Car_{CarID.ToString("D3")}!");
            // Here you could call something like GameManager.Instance.CollectItem(CarID);
            hasItem = false;
            if (mapMarker != null) mapMarker.SetActive(false); // hide red X after found
        }
        else
        {
            Debug.Log($"This car (Car_{CarID.ToString("D3")}) is empty.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactionPrompt != null) interactionPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactionPrompt != null) interactionPrompt.SetActive(false);
        }
    }
}