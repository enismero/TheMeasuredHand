using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Opening");
    }
    public void OtherScene(string sahneadi)
    {
        SceneManager.LoadScene(sahneadi);
    }
}
