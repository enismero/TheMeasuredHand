using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices; //hata mesajı için 
using System;

public class metre : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [Header("area")]
    public RectTransform play;
    public RectTransform continueArea;
    public RectTransform settings;
    public RectTransform quit;
    public float metrehizi=10f;
    private Vector3 startPos;
    private RectTransform rectTrans;

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    void Start()
    {
        rectTrans=GetComponent<RectTransform>();
        startPos=rectTrans.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StopAllCoroutines();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTrans,eventData.position,eventData.pressEventCamera,out globalMousePos))
        {
            globalMousePos.y=startPos.y;
            if (globalMousePos.x < startPos.x)
            {
                globalMousePos.x=startPos.x;
            }
            rectTrans.position=globalMousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(play, eventData.position, eventData.pressEventCamera))
        {
            Debug.Log("başladı");
            SceneManager.LoadScene("OpeningAnimation");
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(continueArea, eventData.position, eventData.pressEventCamera))
        {
            rectTrans.position=startPos;
            FindAnyObjectByType<Esc>().OyunaDevamEt();
            return;
        }
        else if(RectTransformUtility.RectangleContainsScreenPoint(settings, eventData.position, eventData.pressEventCamera))
        {

            Debug.Log("ayarlar");
            string mesaj = "Tasarımcılarımı bekliyorum.";
            string baslik = "Bu tasarım henüz mevcut değil";
            uint mesajTipi = 0x10 | 0x00;
            MessageBox(IntPtr.Zero, mesaj, baslik, mesajTipi);
        }
        else if(RectTransformUtility.RectangleContainsScreenPoint(quit, eventData.position, eventData.pressEventCamera))
        {
            Debug.Log("çıkış");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying=false;
            #else
                Application.Quit();
            #endif
        }
        StartCoroutine(GeriSayim());
    }

    private IEnumerator GeriSayim()
    {
        while (Vector3.Distance(rectTrans.position, startPos) > 0.1f)
        {
            rectTrans.position=Vector3.Lerp(rectTrans.position,startPos,Time.deltaTime*metrehizi);
            yield return null;
        }
        rectTrans.position=startPos;
    }
}
