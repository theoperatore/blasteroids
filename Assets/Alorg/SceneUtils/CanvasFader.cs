using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alorg.SceneUtils
{
  public class CanvasFader : MonoBehaviour
  {

    public bool hideOnAwake = false;

    private CanvasGroup canvasGroup = null;

    private void Awake()
    {
      canvasGroup = GetComponent<CanvasGroup>();
      if (hideOnAwake)
      {
        HideImmediate();
      }
      else
      {
        ShowImmediate();
      }

    }

    public void HideImmediate()
    {
      canvasGroup.alpha = 0;
      canvasGroup.interactable = false;
      canvasGroup.blocksRaycasts = false;
    }

    public void ShowImmediate()
    {
      canvasGroup.alpha = 1;
      canvasGroup.interactable = true;
      canvasGroup.blocksRaycasts = true;
    }

    public void FadeIn(float time = 0.1f)
    {
      canvasGroup.interactable = true;
      canvasGroup.blocksRaycasts = true;
      StartCoroutine(FadeInCanvasGroup(time, canvasGroup));
    }

    public void FadeOut(float time = 0.1f)
    {
      canvasGroup.interactable = false;
      canvasGroup.blocksRaycasts = false;
      StartCoroutine(FadeOutCanvasGroup(time, canvasGroup));
    }

    private IEnumerator FadeOutCanvasGroup(float time, CanvasGroup target)
    {
      while (target.alpha > 0)
      {
        target.alpha -= Time.deltaTime / time;
        yield return null;
      }
    }

    private IEnumerator FadeInCanvasGroup(float time, CanvasGroup target)
    {
      while (target.alpha < 1)
      {
        target.alpha += Time.deltaTime / time;
        yield return null;
      }
    }
  }
}
