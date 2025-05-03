using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [Header("Car Settings")]
    public int CarID;
    public bool hasItem = false;
    [Header("Item")]
    public string itemName; // "GasCan", "Fuse", or "Wrench"
    public bool containsBattery = false;
    private float batteryChance = 0.2f; // 20% chance by default

    [Header("UI & Interaction")]
    public GameObject mapMarker; // Assigned by GameManager
    public GameObject interactionPrompt; // TODO

    private bool isPlayerNear = false;

    void Awake()
    {
    }

    void Start(){
        if (interactionPrompt != null){
            interactionPrompt.SetActive(false);
        }
        containsBattery = Random.value < batteryChance;
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
    UIManager uiManager = FindAnyObjectByType<UIManager>();

    if (hasItem)
    {
        PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
        if (inventory != null)
        {
            inventory.CollectItem(itemName);
        }
        hasItem = false;
        if (mapMarker != null){
            mapMarker.SetActive(false);
        }
        if (uiManager != null){
            uiManager.ShowMessage($"{itemName} found.");
        } 
    }
    else if (!hasItem && !containsBattery && uiManager != null)
        {
            uiManager.ShowMessage("Empty car.");
        }
    if (containsBattery)
    {
        FlashlightToggle flashlight = FindAnyObjectByType<FlashlightToggle>();
        if (flashlight != null)
        {
            flashlight.RechargeBattery();
        }
        containsBattery = false;
        if (uiManager != null) uiManager.ShowMessage("Flashlight battery found");
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