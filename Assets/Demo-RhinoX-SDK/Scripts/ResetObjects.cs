using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour
{
    public List<GameObject> ObjectsToBeReset = new List<GameObject>();

    Dictionary<GameObject, Pose> InitialPoses = new Dictionary<GameObject, Pose>();

    private void Awake()
    {
        //remember the initial poses:
        foreach(var go in ObjectsToBeReset)
        {
            InitialPoses.Add(go, new Pose(go.transform.position, go.transform.rotation));
        }
    }

    public void ResetObjs()
    {
        foreach(var go in InitialPoses.Keys)
        {
            go.transform.position = InitialPoses[go].position;
            go.transform.rotation = InitialPoses[go].rotation;

            if (go.GetComponent<Ximmerse.RhinoX.Throwable>())
            {
                go.GetComponent<Ximmerse.RhinoX.Throwable>().RigibodySleep();
            }
        }
    }
}
