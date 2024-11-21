using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    [SerializeField] private List<GameObject> carModels = new List<GameObject>();

    private GameObject selectedCar;

    private void Awake()
    {
        selectedCar = carModels[0];
    }

    public void SelectCar(int index)
    {
        if(index < 0 || index >= carModels.Count)
        {
            Debug.LogError("Invalid index");
            return;
        }

        selectedCar = carModels[index];
        Debug.Log("[CarSelection] Selected car: " + selectedCar.name);
    }

    public void AcceptSelection()
    {
        RaceConfigurations.Instance.SetCarModel(selectedCar);
    }
}
