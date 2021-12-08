using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float fadeTime;
    public float destroyTime;
    public Renderer rend;
    private float alpha;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("g");
            StartCoroutine(Fading());
        }
    }

    public IEnumerator Fading()
    {
        alpha = rend.material.color.a;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime / fadeTime;
            rend.material.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        Destroy(transform.parent.gameObject, destroyTime);
        Debug.Log("b");
        yield break;
    }
}
