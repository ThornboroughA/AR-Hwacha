using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingTest : MonoBehaviour
{
    private bool modelActive = false;
    [SerializeField] private GameObject testSphere = null;

    private void Update()
    {
        if (modelActive)
        {
            testSphere.SetActive(true);
        } else
        {
            testSphere.SetActive(false);
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
