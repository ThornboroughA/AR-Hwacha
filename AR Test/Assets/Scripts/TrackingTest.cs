using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingTest : MonoBehaviour
{
    public bool modelActive = false;

    [SerializeField] private GameObject arrows = null;
    [SerializeField] private GameObject fireButton = null;

    public static TrackingTest instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Another copy of TrackingTest found!");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (modelActive)
        {
            arrows.SetActive(true);
            fireButton.SetActive(true);
        } else
        {
            arrows.SetActive(false);
            fireButton.SetActive(false);
        }
    }

    public void ModelFound()
    {
        print("MODEL FOUND!");
        modelActive = true;
    }
    public void ModelLost()
    {
        print("MODEL LOST!");
        modelActive = false;
    }


}
