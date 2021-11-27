using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InControlManager : MonoBehaviour
{
    public GameObject[] mobileControl;

    private void Awake() {
        #if UNITY_ANDROID
        for (int i = 0; i < mobileControl.Length; i++)
        {
            mobileControl[i].SetActive(false);
        }
        #endif
    }
}
