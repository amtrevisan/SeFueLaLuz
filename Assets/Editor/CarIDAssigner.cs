using UnityEditor;
using UnityEngine;

public class CarIDAssigner : MonoBehaviour
{
    [MenuItem("Tools/Assign Car IDs Automatically")]
    public static void AssignCarIDs()
    {
        // Find all CarInteraction objects in the scene
        CarInteraction[] cars = FindObjectsOfType<CarInteraction>();
        
        // Sort cars by their position in the hierarchy (top to bottom)
        System.Array.Sort(cars, (car1, car2) => car1.transform.GetSiblingIndex().CompareTo(car2.transform.GetSiblingIndex()));

        int count = 1;

        foreach (CarInteraction car in cars)
        {
            car.CarID = count;
            car.gameObject.name = $"Car_{count:D2}"; // Name the car like "Car_01", "Car_02"
            EditorUtility.SetDirty(car); // Mark the object as modified
            count++;
        }

        Debug.Log("Car IDs assigned to all CarInteraction objects.");
    }
}
