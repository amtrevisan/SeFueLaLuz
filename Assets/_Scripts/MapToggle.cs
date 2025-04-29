using UnityEngine;

public class MapToggle : MonoBehaviour
{
    public GameObject mapUI; // Reference to the map UI object

    void Update()
    {
        // Check for the 'M' key press to toggle the map visibility
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            mapUI.SetActive(!mapUI.activeSelf); // Toggle between active and inactive
        }
    }
}
