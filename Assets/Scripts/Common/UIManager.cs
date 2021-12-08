using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    Text WoodText = null;

    [SerializeField]
    Text TimeLimitText = null;

    protected override void Awake()
    {
        isDontDestroy = false;
        base.Awake();

    }
    private void Start()
    {
        if (WoodText)
            WoodText.text = GameManager.instance.getParseWoodCount();
    }
    public void UpdateWoodText()
    {
        if(WoodText)
            WoodText.text = GameManager.instance.getParseWoodCount();
    }
    public void UpdateTimeLimitText(string _str)
    {
        if(TimeLimitText)
            TimeLimitText.text = _str;
    }

}
