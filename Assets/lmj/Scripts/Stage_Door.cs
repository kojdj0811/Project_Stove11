using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Door : MonoBehaviour
{
    [SerializeField]
    private int StageNumber = -1;

    [SerializeField]
    private GameObject root;

    [SerializeField]
    private BoxCollider triggerCollider;

    [SerializeField]
    private float smoothRotate = 5.0f;

    Coroutine _DoorCoroutine = null;

    [SerializeField]
    List<Mesh> meshes = new List<Mesh>();

    [SerializeField]
    MeshFilter mesh = null;


    private void Start()
    {

        if (triggerCollider == null)
        {
            Debug.LogError("triggerCollider == null" + gameObject.name);
        }


        if (StageNumber <= -1 || StageNumber > 5)
        {
            Debug.LogError("Door StageNumberError");
        }
        else
        {
            if (StageManager.instance.GetstageClear(StageNumber))
            {
                triggerCollider.enabled = false;
            }
            mesh.mesh = meshes[StageNumber - 1];


        }

        if (root == null)
        {
            Debug.LogError("Door root == null" + gameObject.name);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        jdj.WanderfullCharacterController _controller = other.GetComponent<jdj.WanderfullCharacterController>();
        if (_controller)
        {
            if(_DoorCoroutine != null)
            {
                StopCoroutine(_DoorCoroutine);
            }

            _DoorCoroutine = StartCoroutine(OpenDoor());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        jdj.WanderfullCharacterController _controller = other.GetComponent<jdj.WanderfullCharacterController>();
        if (_controller)
        {
            if (_DoorCoroutine != null)
            {
                StopCoroutine(_DoorCoroutine);
            }

            _DoorCoroutine = StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {

        while (true)
        {
            Vector3 rot = root.transform.localRotation.eulerAngles;
            float roty = Mathf.LerpAngle(rot.y, 90.0f, smoothRotate * Time.deltaTime);
            root.transform.localEulerAngles = new Vector3(0, roty, 0);

            if (Mathf.Approximately(roty, 90.0f))
            {
                break;
            }
            else
                yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        while (true)
        {
            Vector3 rot = root.transform.localRotation.eulerAngles;
            float roty = Mathf.LerpAngle(rot.y, 0.0f, smoothRotate * Time.deltaTime);
            root.transform.localEulerAngles = new Vector3(0, roty, 0);

            if (Mathf.Approximately(roty, 0.0f))
            {
                break;
            }
            else
                yield return null;
        }
    }
}
