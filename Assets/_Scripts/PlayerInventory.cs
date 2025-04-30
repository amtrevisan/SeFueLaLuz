using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject gasCanIcon;
    public GameObject fuseIcon;
    public GameObject wrenchIcon;

    private bool hasGas = false;
    private bool hasFuse = false;
    private bool hasWrench = false;

    public void CollectItem(string itemName)
    {
        switch (itemName)
        {
            case "GasCan":
                hasGas = true;
                if (gasCanIcon != null) gasCanIcon.SetActive(true);
                break;
            case "Fuse":
                hasFuse = true;
                if (fuseIcon != null) fuseIcon.SetActive(true);
                break;
            case "Wrench":
                hasWrench = true;
                if (wrenchIcon != null) wrenchIcon.SetActive(true);
                break;
            default:
                Debug.LogWarning("Unknown item: " + itemName);
                break;
        }
    }

    public bool HasAllItems()
    {
        return hasGas && hasFuse && hasWrench;
    }
}