using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityRandomizer : MonoBehaviour
{
    public int buildingAmount, index, residentialUnits, nonResidentialSqft, buildingSqft, stories, buildingTypeId, yearBuilt;

    // Start is called before the first frame update
    void Start()
    {
        // Generate random values for all the buildings
        buildingAmount = 100;
        residentialUnits = Random.Range(0, 6);
        nonResidentialSqft = Random.Range(0, 4000);
        buildingSqft = Random.Range(0, 4000);
        stories = Random.Range(0, 4);
        buildingTypeId = Random.Range(0, 15);
        
        for (int i = 0; i < buildingAmount; i++) {
            index = i;
        }

        Debug.Log("Residential units " + residentialUnits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
