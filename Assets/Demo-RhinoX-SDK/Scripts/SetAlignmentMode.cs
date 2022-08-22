using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlignmentMode : MonoBehaviour
{
    public Ximmerse.RhinoX.Grabable targetGrabable;

	public void SetAlignmentMode_FullAlign()
	{
        targetGrabable.AlignMode = Ximmerse.RhinoX.Grabable.AlignmentMode.FullAlign;
    }

    public void SetAlignmentMode_DontAlign()
    {
        targetGrabable.AlignMode = Ximmerse.RhinoX.Grabable.AlignmentMode.DontAlign;
    }
}
