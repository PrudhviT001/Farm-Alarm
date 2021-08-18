using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Tool")]
public class Tool : ScriptableObject
{
	public Sprite sprite;
	public ToolType toolType;
}

public enum ToolType
{
	Plow,
	Watercan
}
