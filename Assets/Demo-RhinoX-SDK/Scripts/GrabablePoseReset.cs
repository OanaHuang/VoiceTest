using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ximmerse.RhinoX;
using Pose = UnityEngine.Pose;

[RequireComponent(typeof(Grabable))]
public class GrabablePoseReset : MonoBehaviour
{
    Grabable grabable;

    Outline outline;

    public GameObject outlineFrame;//the outline frame game object

    Pose beginPose;

    bool matchPose = false;

    Material mat_OutlineFrame_Fill;

    private void Awake()
    {
        grabable = GetComponent<Grabable>();
        outline = GetComponent<Outline>();
        grabable.OnGrabBegin += Grabable_OnGrabBegin;
        grabable.OnGrabUpdate += Grabable_OnGrabUpdate;
        grabable.OnGrabEnd += Grabable_OnGrabEnd;

        outlineFrame.SetActive(false);
        mat_OutlineFrame_Fill = outlineFrame.GetComponent<Renderer>().materials[1];//2nd mat : outline fill mat
    }

    private void Grabable_OnGrabUpdate(PlayerHand hand, Grabable grabable)
    {
        var pDiff = Vector3.SqrMagnitude(beginPose.position - grabable.transform.position);
        var qDiff = Quaternion.Angle(this.beginPose.rotation, transform.localRotation);
        matchPose = (pDiff <= 0.01f || qDiff <= 1.5f);//match pose
        if (matchPose && mat_OutlineFrame_Fill)
        {
            mat_OutlineFrame_Fill.SetColor("_OutlineColor", Color.green);//显示提示边框颜色 = 绿色。
        }
        else if (!matchPose && mat_OutlineFrame_Fill)
        {
            mat_OutlineFrame_Fill.SetColor("_OutlineColor", Color.yellow);//显示提示边框颜色 = 黄色。
        }
    }

    /// <summary>
    /// On grab ends
    /// </summary>
    /// <param name="hand"></param>
    /// <param name="grabable"></param>
    private void Grabable_OnGrabEnd(PlayerHand hand, Grabable grabable)
    {
        if (matchPose)
        {
            //reset when pose is matched. 
            StartCoroutine(TweenToPose(this.beginPose, 0.1f));
        }
        if (outline)
            outline.enabled = true;//enable outline at grab ends
        outlineFrame.SetActive(false);
    }

    /// <summary>
    /// On grab begins
    /// </summary>
    /// <param name="hand"></param>
    /// <param name="grabable"></param>
    private void Grabable_OnGrabBegin(PlayerHand hand, Grabable grabable)
    {
        outlineFrame.transform.SetPositionAndRotation(grabable.transform.position, grabable.transform.rotation);
        beginPose = new Pose(grabable.transform.position, grabable.transform.rotation);
        if (outline)
            outline.enabled = false;//disable outline at grab begins
        outlineFrame.SetActive(true);
    }

    private void OnDestroy()
    {
        grabable.OnGrabBegin -= Grabable_OnGrabBegin;
        grabable.OnGrabUpdate -= Grabable_OnGrabUpdate;
        grabable.OnGrabEnd -= Grabable_OnGrabEnd;
    }

    IEnumerator TweenToPose(Pose pose, float duration)
    {
        float st = Time.time;
        var startP = transform.position;
        var startQ = transform.rotation;
        while ((Time.time - st) <= duration)
        {
            float t = (Time.time - st) / duration;
            transform.position = Vector3.Lerp(startP, pose.position, t);
            transform.rotation = Quaternion.Lerp(startQ, pose.rotation, t);
            yield return null;
        }
        transform.position = pose.position;
        transform.rotation = pose.rotation;
    }

}
