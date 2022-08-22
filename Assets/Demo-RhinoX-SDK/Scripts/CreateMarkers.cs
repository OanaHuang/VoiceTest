using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ximmerse.RhinoX;

public class CreateMarkers : MonoBehaviour
{
    public int FrameMarkerID, ToMarkerID;

    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = FrameMarkerID; i < ToMarkerID; i++)
        {
            GameObject marker = new GameObject(i.ToString(), new System.Type[] { typeof(TrackableIdentity),
            typeof(DynamicTarget)});
            marker.GetComponent<TrackableIdentity>().TrackableID = i;
            marker.GetComponent<DynamicTarget>().DebugView = true;

            marker.transform.SetParent(this.transform);
        }
    }
}
