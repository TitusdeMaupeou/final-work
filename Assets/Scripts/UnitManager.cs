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

   private InputReader _reader;
   private MessageBox _textBox;
   private unitSelection _unitSelection;
   private Vector3 _buildingPosition;
   private Quaternion _buildingRotation;
   private Hello_requester _req;
    void Start()
    {
        _reader = GameObject.Find("OSC").GetComponent<Input_reader>();
        _textBox = GameObject.Find("BuildingMenu").GetComponent<MessageBox>();
        _unitSelection = GameObject.Find("UnitList").GetComponent<_unitSelection>();
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
        foreach (int id in _reader.positions.Keys)
        {
            if (!buildings.ContainsKey(id)) //check if dictionary contains id
            {
                _textBox.Show(); //if not, show UI
            }
        }
    }

    //buildings with new marker get instantiated when button is pressed
    public void InstantiateBuildings()
    {
        foreach (int id in _reader.positions.Keys)
        {
            if (!buildings.ContainsKey(id))
            {
                prefab = __unitSelection.activeGameobject;
                GameObject newBuilding = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                newBuilding.name = id.ToString();
                //newBuilding.transform.localScale = __unitSelection.unitScale;
                buildings.Add(id, newBuilding);
            }
        }
    }

    public void MoveBuildings()
    {
        foreach (int id in _reader.positions.Keys)
        {
           if (buildings.ContainsKey(id)) { 
            _buildingPosition.x = _reader.positions[id].x;
            _buildingPosition.y = 6.8f;
            _buildingPosition.z = _reader.positions[id].y;
            buildings[id].transform.position = _buildingPosition;
            }
        }
    }
    public void RotateBuildings()
    {
        foreach (int id in _reader.rotations.Keys)
        {
            if (buildings.ContainsKey(id))
            {
                _buildingRotation = _reader.rotations[id];
                buildings[id].transform.rotation = _buildingRotation;
            }
        }
    }
}

