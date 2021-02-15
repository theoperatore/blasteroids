using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attribute", menuName = "Blasteroids/Attribute", order = 0)]
public class Attribute : ScriptableObject
{
  public float value = 0;
  public string attributeName = "";

  [TextArea]
  public string attributeDesc = "";

}
