using UnityEngine;
using UnityEngine.InputSystem;

public class Esc : MonoBehaviour
{
    [Header("uı settings")]
    public GameObject pausepanel;
    public static bool oyunDurduMu=false;

    void Update()
    {
        if (Keyboard.current!=null&&Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("esc basıldı");
            if (oyunDurduMu)
            {
                OyunaDevamEt();
            }
            else
            {
                OyunuDurdur();
            } 
        }  
    }
    public void OyunuDurdur()
    {
        pausepanel.SetActive(true);
        //Time.timeScale=0f;
        oyunDurduMu=true;
    }
    public void OyunaDevamEt()
    {
        pausepanel.SetActive(false);
        //Time.timeScale=1f;
        oyunDurduMu=false;
    }
}
