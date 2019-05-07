using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityRandomizer : MonoBehaviour
{
    Random rand = new Random();
    int buildingAmount = 100;
    int index, residentialUnits, nonResidentialUnits, buildingSqft, stories, buildingTypeId, yearBuilt;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < buildingAmount; i++) {
            residentialUnits = rand.Next();
            Debug.Log(residentialUnits);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
