
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Stageinfo
{
	public int narration;
	public int sprites;
}

[Serializable]
[CreateAssetMenu(fileName = "StageinfoConfiguration", menuName = "StageinfoConfiguration", order = 0)]
public class StageinfoConfiguration : ScriptableObject
{
	public List<Stageinfo> stageinfos;
}
