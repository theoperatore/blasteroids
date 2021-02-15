using UnityEngine;
using TMPro;

public class AttributeDisplay : MonoBehaviour
{
  public Attribute attribute;
  public TMP_Text text;

  void Start()
  {
    text.text = ((int)attribute.value).ToString();
  }

  void Update()
  {
    text.text = ((int)attribute.value).ToString();
  }
}
