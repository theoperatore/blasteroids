using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alorg.SceneUtils
{
  public class SceneUtils : MonoBehaviour
  {
    public void LoadNextScene()
    {
      int currentIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadSceneAtIndex(int idx)
    {
      SceneManager.LoadScene(idx);
    }

    public void ReloadCurrentScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
      SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
  }
}
