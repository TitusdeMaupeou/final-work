using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public GameObject[] unitList;
    public int index;
    public GameObject activeGameobject;

    // Start is called before the first frame update
    void Start()
    {
        unitList = new GameObject[transform.childCount];

        for (int i = 0;i < transform.childCount; i++)
        { 
            unitList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in unitList) { 
                go.SetActive(false);
        }

        if (unitList[0]) {
            unitList[0].SetActive(true);
        }
    }

    public void ChangeUnitScale(float scale)
    {
        foreach (GameObject unit in unitList)
        {
            if (unit.activeInHierarchy)
            {
                unit.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

    public void ToggleLeft()
    {
        unitList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = unitList.Length - 1;
        }
        unitList[index].SetActive(true);
        Debug.Log(unitList[index].gameObject);
        activeGameobject = unitList[index].gameObject;
    }

    public void Update()
    {
    }

    public void ToggleRight()
    {
        unitList[index].SetActive(false);
        index++;
        if (index > unitList.Length - 1)
        {
            index = 0;
        }
        unitList[index].SetActive(true);
        activeGameobject = unitList[index].gameObject;
    }
}
