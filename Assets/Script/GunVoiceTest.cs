using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ximmerse.RhinoX;

public class GunVoiceTest : MonoBehaviour
{
    private AudioSource player;
    public AudioClip clip;

    void Start()
        {
            player = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) || RXInput.IsButtonDown(RhinoXButton.ControllerTouchPadButton))
            {
                player.clip = Resources.Load<AudioClip>("Gun_Release");
                player.Play();
                Debug.Log("Gun_Release");
            }

            if (Input.GetKeyDown(KeyCode.S) || RXInput.IsButtonDown(RhinoXButton.App))
            {
                player.clip = Resources.Load<AudioClip>("Gun_update");
                player.Play();
                Debug.Log("Gun_update");
            }

            if (Input.GetKeyDown(KeyCode.D) || RXInput.IsButtonDown(RhinoXButton.Home))
            {
                player.clip = Resources.Load<AudioClip>("Gun_Reload");
                player.Play();
                Debug.Log("Gun_Reload");
            }

            if (Input.GetKeyDown(KeyCode.F) || RXInput.IsButtonDown(RhinoXButton.ControllerTrigger))
            {
                player.clip = Resources.Load<AudioClip>("枪声");
                //player.Play();
                AudioSource.PlayClipAtPoint(clip, ARCamera.Instance.transform.position);
                Debug.Log("枪声");
            }
        }


    
}
