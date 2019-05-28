using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityOSC;

public class DataRequester : MonoBehaviour
{
    //Script to receive messages from Openframeworks and send OSC messages to Urbansim
    private OSCHandler _oscHandler;
    private string _clientId;
    private IPAddress _dest;
    private int _port;
    private List<string> _values;

    // Start is called before the first frame update
    void Start()
    {
        _clientId = "";
        _dest = IPAddress.Parse("127.0.0.1");
        _port = 4646;
        //create client that should receive the data request;
        _oscHandler.CreateClient(_clientId, _dest, _port); 
    }

   // Update is called once per frame
   public void RequestData(string address) {
       //send the message
       _oscHandler.SendMessageToClient(_clientId, address, _values);
   }
}
