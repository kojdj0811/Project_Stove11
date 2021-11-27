using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallArea : MonoBehaviour
{
    public float reloadSceneDelay = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            MinsuTransitionManager.DoRetryTransition();

            //StartCoroutine(DoAfter());
            
            Debug.Log("Fall Dead...");
        }
    }

    IEnumerator DoAfter()
    {
        yield return new WaitForSeconds(reloadSceneDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }
}
