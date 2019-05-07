using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using IronPython.Hosting;
using Microsoft.Scripting.Hosting;



public class UnitManager : MonoBehaviour {

   public GameObject building;
   public Dictionary<int, GameObject> buildings;
   public GameObject[] list;
   public GameObject prefab;

   private InputReader reader;
   private MessageBox textBox;
   private UnitSelection unitSelection;
   private Vector3 buildingPosition;
   private Quaternion buildingRotation;
   private RunSim simulation;
   private HelloRequester req;
    void Start()
    {
        reader = GameObject.Find("OSC").GetComponent<InputReader>();
        textBox = GameObject.Find("BuildingMenu").GetComponent<MessageBox>();
        unitSelection = GameObject.Find("UnitList").GetComponent<UnitSelection>();
        buildings = new Dictionary<int, GameObject>();

    }

   void Update()
    {
        ShowUI(); //show UI when introducing new marker
        MoveBuildings(); //move them around
        //RotateBuildings(); //rotate them
    }

    void ShowUI()
    {
        foreach (int id in reader.positions.Keys)
        {
            if (!buildings.ContainsKey(id)) //check if dictionary contains id
            {
                textBox.Show(); //if not, show UI
            }
        }
    }

    //buildings with new marker get instantiated when button is pressed
    public void InstantiateBuildings()
    {
        foreach (int id in reader.positions.Keys)
        {
            if (!buildings.ContainsKey(id))
            {
                prefab = unitSelection.activeGameobject;
                GameObject newBuilding = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                newBuilding.name = id.ToString();
                //newBuilding.transform.localScale = unitSelection.unitScale;
                buildings.Add(id, newBuilding);
            }
        }
    }

    public void MoveBuildings()
    {
        foreach (int id in reader.positions.Keys)
        {
           if (buildings.ContainsKey(id)) { 
            buildingPosition.x = reader.positions[id].x;
            buildingPosition.y = 6.8f;
            buildingPosition.z = reader.positions[id].y;
            buildings[id].transform.position = buildingPosition;
            }
        }
    }
    public void RotateBuildings()
    {
        foreach (int id in reader.rotations.Keys)
        {
            if (buildings.ContainsKey(id))
            {
                buildingRotation = reader.rotations[id];
                buildings[id].transform.rotation = buildingRotation;
            }
        }
    }
}

