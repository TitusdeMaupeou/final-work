using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunSim : MonoBehaviour
{
    private PythonInstance pythonInstance;
    // Start is called before the first frame update
    void Start()
    {
        pythonInstance = new PythonInstance();
    }

    public void RunTest()
    {
        //pythonInstance.PatchParameter("fill_nas_from_config", 0, "testje.py");
    }

    void RunHedonicSimulate()
    {
        pythonInstance.PatchParameter("hedonic_simulate", 1, "utils.py");
    }

    void RunLcmEstimate()
    {
        pythonInstance.PatchParameter("lcm_estimate", 2, "utils.py");
    }

    void RunDeveloper()
    {
        pythonInstance.PatchParameter("run-developer", 3, "utils.py");
    }


}
