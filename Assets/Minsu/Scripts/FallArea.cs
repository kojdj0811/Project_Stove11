using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(DoAfter());
            
            Debug.Log("Fall Dead...");
        }
    }

    IEnumerator DoAfter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }
}
