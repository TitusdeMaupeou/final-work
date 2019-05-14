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

    private HelloRequester _requester;


    void Start()
    {
        screen.SetActive(false);
        text = GetComponent<Text>();
    }


    public void Show()
    {
        screen.SetActive(true);
    }

    public void SendDataRequest() {
        _requester.Run(); //get parameter here
    }
}
