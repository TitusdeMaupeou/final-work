using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public GameObject screen;
    public InputField type;
    public Button button;
    public Text text;


    void Start()
    {
        screen.SetActive(false);
        text = GetComponent<Text>();
    }


    public void Show()
    {
        screen.SetActive(true);
    }
}
