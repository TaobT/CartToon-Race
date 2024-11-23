using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceConfigurations : MonoBehaviour
{
    public static RaceConfigurations Instance { get; private set; }

    private GameObject carModel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetCarModel(GameObject carModel)
    {
        this.carModel = carModel;
    }

    public GameObject GetCarModel()
    {
        return carModel;
    }
}
