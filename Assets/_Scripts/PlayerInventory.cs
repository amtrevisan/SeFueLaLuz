using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI Icons")]
    public GameObject gasCanIcon;
    public GameObject fuseIcon;
    public GameObject wrenchIcon;

    public void CollectItem(string itemName)
    {
        switch (itemName)
        {
            case "GasCan":
                if (gasCanIcon != null) gasCanIcon.SetActive(true);
                break;
            case "Fuse":
                if (fuseIcon != null) fuseIcon.SetActive(true);
                break;
            case "Wrench":
                if (wrenchIcon != null) wrenchIcon.SetActive(true);
                break;
            default:
                Debug.LogWarning("Unknown item: " + itemName);
                break;
        }
    }
}