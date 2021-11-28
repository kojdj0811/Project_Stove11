using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Door : MonoBehaviour
{
    [SerializeField]
    private int StageNumber = -1;

    [SerializeField]
    private TextMesh DoorText = null;

    [SerializeField]
    private GameObject root;

    [SerializeField]
    private BoxCollider triggerCollider;

    [SerializeField]
    private float smoothRotate = 5.0f;

    jdj.WanderfullCharacterController controller =  null;
    Coroutine _openDoorCoroutine = null;
    Coroutine _closeDoorCoroutine = null;

    private void Start()
    {

        if (triggerCollider == null)
        {
            Debug.LogError("triggerCollider == null" + gameObject.name);
        }


        if (StageNumber == -1 || StageNumber > 5)
        {
            Debug.LogError("Door StageNumberError");
        }
        else
        {
            if(StageManager.instance.GetstageClear(StageNumber))
            {
                triggerCollider.enabled = false;
            }
        }

        if(root == null)
        {
            Debug.LogError("Door root == null" + gameObject.name);
        }    

        if(DoorText == null)
        {
            Debug.LogError("DoorText == null");
        }
        else
        {
            DoorText.text = StageNumber.ToString();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(controller == null)
        {
            jdj.WanderfullCharacterController _controller = other.GetComponent<jdj.WanderfullCharacterController>();
            if(_controller)
                controller = _controller;
        }
        
        if (controller)
        {
            if (_closeDoorCoroutine != null)
            {
                StopCoroutine(_closeDoorCoroutine);
                _closeDoorCoroutine = null;
            }

            if (_openDoorCoroutine == null)
            {
                _openDoorCoroutine = StartCoroutine(OpenDoor());
            }

          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        jdj.WanderfullCharacterController _controller = other.GetComponent<jdj.WanderfullCharacterController>();
        if (_controller)
        {
            controller = null;
            if(_openDoorCoroutine != null)
            {
                StopCoroutine(_openDoorCoroutine);
                _openDoorCoroutine = null;
            }
        }

        if(_closeDoorCoroutine == null)
        {
            _closeDoorCoroutine = StartCoroutine(CloseDoor());
        }
    }
    IEnumerator OpenDoor()
    {
        Debug.Log("eulerAngles : " + root.transform.localRotation.eulerAngles);

        while (true)
        {
            Vector3 rot = root.transform.localRotation.eulerAngles;
            float roty = Mathf.LerpAngle(rot.y, 90.0f, smoothRotate * Time.deltaTime);
            root.transform.localEulerAngles = new Vector3(0, roty, 0);

            if (Mathf.Approximately(roty, 90.0f))
            {
                _openDoorCoroutine   = null;
                break;
            }
            else
                yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        Debug.Log("eulerAngles : " + root.transform.localRotation.eulerAngles);
        while (true)
        {
            Vector3 rot = root.transform.localRotation.eulerAngles;
            float roty = Mathf.LerpAngle(rot.y, 0.0f, smoothRotate * Time.deltaTime);
            root.transform.localEulerAngles = new Vector3(0, roty, 0);

            if (Mathf.Approximately(roty, 0.0f))
            {
                _closeDoorCoroutine = null;
                break;
            }
            else
                yield return null;
        }
    }

}
