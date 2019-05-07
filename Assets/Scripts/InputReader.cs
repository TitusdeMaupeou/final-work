using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class InputReader : MonoBehaviour {

	public OSCReciever reciever;
	public OSCBundle bundle;
    public int port = 4646;
    public Dictionary<int, Vector3> positions = new Dictionary<int, Vector3>();
    public Dictionary<int, Quaternion> rotations = new Dictionary<int, Quaternion>();

    void Start () {
        Debug.Log("Inputreader started");
		reciever = new OSCReciever();
		reciever.Open(port);
	}
	
	// Update is called once per frame
	void Update () {
		ReceiveMessages();
	}

	public void ReceiveMessages() {
        if (reciever.hasWaitingMessages()) {
            positions.Clear();
            OSCMessage msg = reciever.getNextMessage();
            //Debug.Log(string.Format("message received: {0} {1}", msg.Address, msg.Data.ToString()));
            DataToPosition(msg.Data);      
        }
    }

	private Dictionary<int, Vector3> DataToPosition(List<object> data)
	{
        int markerId = (int)data[0]; //save id
        float x = (float)data[1]; //save x-coordinate
		float y = (float)data[2]; //save y-coordinate
		float z = (float)data[3]; //save z-coordinate
        Vector3 position = new Vector3(x, y, z);

        positions.Add(markerId, position);

        return positions;
	}	

    private Dictionary<int, Quaternion> DataToRotation(List<object> data)
    {
        int markerId = (int)data[0]; //save id
        float xRot = (float)data[4]; //save rotation
        float yRot = (float)data[5];
        float zRot = (float)data[6];

        Quaternion rotation = new Quaternion(xRot, yRot, zRot, 1);

        rotations.Add(markerId, rotation);
       
        return rotations;
    }
	
}
