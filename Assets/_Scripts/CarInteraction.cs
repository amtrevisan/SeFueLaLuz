using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [Header("Car Settings")]
    public int CarID;
    public bool hasItem = false;
    public bool canHaveBattery = true; // Optional setting to control battery spawns

    [Header("Item")]
    public string itemName; // "GasCan", "Fuse", or "Wrench"
    public bool containsBattery = false;
    public float batteryChance = 1f; // 20% chance by default

    [Header("UI & Interaction")]
    public GameObject mapMarker; // Assigned by GameManager
    public GameObject interactionPrompt; // TODO

    private bool isPlayerNear = false;

    void Awake()
    {
    }

    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);

        if (canHaveBattery)
        {
            containsBattery = true;
        }
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
            PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectItem(itemName);
            }

            if (containsBattery)
            {
                FlashlightToggle flashlight = FindAnyObjectByType<FlashlightToggle>();
                if (flashlight != null)
                {
                    flashlight.RechargeBattery();
                    Debug.Log("You also found a battery and recharged your flashlight!");
                }
                containsBattery = false;
            }

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