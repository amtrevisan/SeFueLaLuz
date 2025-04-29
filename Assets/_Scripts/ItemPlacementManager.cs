using UnityEngine;
using System.Collections.Generic;

public class ItemPlacementManager : MonoBehaviour
{
    [System.Serializable]
    public class CarMarkerPair
    {
        public int carID;
        public GameObject markerUI;
    }

    public List<CarMarkerPair> eligibleCars; // List of 10 cars and their corresponding Xs
    public int numberOfItems = 3;

    private List<int> selectedCarIDs = new List<int>();

    void AssignRandomCars()
    {
        string[] items = { "GasCan", "Fuse", "Wrench" };
        Shuffle(items);

        List<CarMarkerPair> pool = new List<CarMarkerPair>(eligibleCars);
        
        for (int i = 0; i < numberOfItems; i++)
        {
            int randIndex = Random.Range(0, pool.Count);
            CarMarkerPair selected = pool[randIndex];
            selectedCarIDs.Add(selected.carID);

            // Activate marker
            selected.markerUI.SetActive(true);

            // Tell the car it has an item
            CarInteraction[] allCars = FindObjectsByType<CarInteraction>(FindObjectsSortMode.None);
            foreach (CarInteraction car in allCars)
            {
                if (car.CarID == selected.carID)
                {
                    car.hasItem = true;
                    car.itemName = items[i];
                    break;
                }
            }

            pool.RemoveAt(randIndex);
        }
    }

    void Shuffle<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rand = Random.Range(i, array.Length);
            (array[i], array[rand]) = (array[rand], array[i]);
        }
    }

    void Start()
    {
        AssignRandomCars();
    }
}
