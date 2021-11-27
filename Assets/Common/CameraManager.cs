using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class CameraManager : MonoSingleton<CameraManager>
{
    private bool isInit = false;

    [Header("Follow Variables"), SerializeField]
    private Transform target;
    public float dist = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;
    private Transform tr;

    [Header("Screen Shake Variables")]
    private float shakeTimeRemaining;
    private float shakePower;
    private float shakeFadeTime;
    private float shakeRotation;
    private float rotationMultiplier;
    private bool isRotating;


    private void Start()
    {
        tr = GetComponent<Transform>();
        isInit = true;
    }
    void LateUpdate()
    {
        if(isInit)
        {
            Follow();

            ScreenShake();
        }
    }

    //LateUpdate에서 실행
    private void Follow()
    {
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up*height);
        tr.LookAt(target);
    }

    //LateUpdate에서 실행
    private void ScreenShake()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            //Random shake 방향
            float xAmount = Random.Range(-0.1f, 0.1f) * shakePower;
            float yAmount = Random.Range(-0.1f, 0.1f) * shakePower;
            //Transform XY + Rotation Z 움직임
            transform.position += new Vector3(xAmount, yAmount, 0);
            transform.rotation = Quaternion.Euler(0, 0, shakeRotation * Random.Range(-1, 1));
            //Shake timer 줄면서 shake power도 줄게됨
            shakePower = Mathf.MoveTowards(shakePower, 0, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        //Rotation reset
        else if (isRotating)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isRotating = false;
        }
    }

    /// <summary>
    /// Length: Shake 기간 | Power: Shake 힘 | rotPower: 회전 shake 힘 |
    /// 예: CameraManager.Instance.StartShake(0.4f, 0.4f, 0.3f);
    public void StartShake(float length, float power, float rotPower)
    {
        shakeTimeRemaining = length;
        shakePower = power;
        shakeFadeTime = power / length;
        rotationMultiplier = rotPower;
        shakeRotation = power * rotationMultiplier;
        isRotating = true;
    }
}
