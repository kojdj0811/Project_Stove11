using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearFootrest : MonoBehaviour
{
    [SerializeField]
    float durationTime = 5.0f;
    //[SerializeField]
    //MeshRenderer meshRenderer = null;
    Coroutine coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(coroutine == null)
            {
                //Material[] materials = meshRenderer.materials;
                //if (materials.Length >0)
                coroutine = StartCoroutine(Disappear());
            }
        }
    }

    IEnumerator Disappear()
    {
        const float _t = 0.1f;
        float alpha = 255.0f;
        float subtractValue = (alpha / durationTime) * _t;

        

        while(true)
        {
            //Material[] materials = meshRenderer.materials;
            alpha -= subtractValue;

            //for (int i = 0; i < materials.Length; i++)
            //{
            //    Color color = materials[i].color;
            //    materials[i].color = new Color(color.r, color.g, color.b, alpha / 255.0f); 
            //}
            //meshRenderer.materials = materials;
            if (alpha <= 0)
            {
                gameObject.SetActive(false);
                break;
            }
            yield return new WaitForSeconds(_t);
        }
    }
}
