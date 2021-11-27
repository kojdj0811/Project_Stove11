using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InControlManager : MonoBehaviour
{
    public Camera inControlCamera;
    public GameObject[] mobileControl;

    private void Awake() {

        int targetLayer = LayerMask.NameToLayer("VirtualJoypad");

        foreach (var cam in Camera.allCameras)
        {
            if(cam != inControlCamera)
                cam.cullingMask = cam.cullingMask & ~(1<<targetLayer);
        }


        #if !UNITY_ANDROID
        for (int i = 0; i < mobileControl.Length; i++)
        {
            mobileControl[i].SetActive(false);
        }
        #endif
    }
}
