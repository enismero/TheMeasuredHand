using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    [Header("sahne")]
    public string sahne;
    public void sahnedeğiş()
    {
        SceneManager.LoadScene(sahne);
    }
}
    
