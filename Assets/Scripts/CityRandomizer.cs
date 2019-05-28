using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityRandomizer : MonoBehaviour
{
    private InputReader _inputReader;
    public int buildingAmount, index, residentialUnits, nonResidentialSqft, buildingSqft, stories, buildingTypeId, yearBuilt;

    // Start is called before the first frame update
    void Start()
    {
        _inputReader = new InputReader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
