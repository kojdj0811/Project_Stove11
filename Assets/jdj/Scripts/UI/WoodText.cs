using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using jdj;

public class WoodText : MonoBehaviour
{
    public Text text;

    void Update()
    {
        if(WanderfullCharacterController.S != null)
            text.text = $"X {WanderfullCharacterController.S.WoodCount}";
    }
}
