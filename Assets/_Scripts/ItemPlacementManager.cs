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

    void Start()
    {
        AssignRandomCars();
    }

    void AssignRandomCars()
    {
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
                    break;
                }
            }

            pool.RemoveAt(randIndex);
        }
    }
}
