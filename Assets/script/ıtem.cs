using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ıtem : MonoBehaviour
{
    public hand akil;
    public karakter buyuDurumu;

    [Header("Eşya stats")]
    public int guc;
    public int ceviklik;
    public int dayaniklilik;
    public int zeka;
    public int karizma;

    [Header("Büyü Görselleri")] 
    public GameObject gucGorseli;
    public GameObject cevGorseli;
    public GameObject dayGorseli;
    public GameObject zekGorseli;
    public GameObject karGorseli;

    [Header("core mechanic")]
    public string istenenBuyu;
    public int buyuDoğru=0; //2 yanlış, 0 nötr, 1 doğru
    //public Animator bolonAnimator;

    public void BuyuDene(string secilenBuyu)
    {
        if(buyuDurumu==null) return;

        if(buyuDurumu.buyuVerildi==false)
        {
            
            buyuDurumu.buyuVerildi=true;
            if (secilenBuyu == istenenBuyu)
            {
                buyuDoğru=1;
                statArttir(secilenBuyu);
                if(akil.akilSağliği!=100) akil.akilSağliği+=25;
                Debug.Log("doğru buyu");
            }
            else
            {
                buyuDoğru=2;
                if(akil.akilSağliği!=0) akil.akilSağliği-=25;
                Debug.Log("yanliş buyu");
            }
        }
        else Debug.Log("zaten buyu var");
    }
    
    public void statArttir(string statType)
    {
        if (buyuDurumu.buyuVerildi != true)
        {
           switch (statType)
        {
            case "guc": guc+=5;
            gucGorseli.SetActive(true);
            cevGorseli.SetActive(false);
            dayGorseli.SetActive(false);
            zekGorseli.SetActive(false);
            karGorseli.SetActive(false);
            
             break;
            case "cev": ceviklik+=5;
            gucGorseli.SetActive(false);
            cevGorseli.SetActive(true);
            dayGorseli.SetActive(false);
            zekGorseli.SetActive(false);
            karGorseli.SetActive(false);
             break;
            case "day": dayaniklilik+=5;
            gucGorseli.SetActive(false);
            cevGorseli.SetActive(false);
            dayGorseli.SetActive(true);
            zekGorseli.SetActive(false);
            karGorseli.SetActive(false);
             break;
            case "zek": zeka+=5;
            gucGorseli.SetActive(false);
            cevGorseli.SetActive(false);
            dayGorseli.SetActive(false);
            zekGorseli.SetActive(true);
            karGorseli.SetActive(false);
             break;
            case "kar": karizma+=5;
            gucGorseli.SetActive(false);
            cevGorseli.SetActive(false);
            dayGorseli.SetActive(false);
            zekGorseli.SetActive(false);
            karGorseli.SetActive(true);
             break;
        } 
        }
        
    }
    public void EsyayıSifirla(Sprite newImage)
    {
        if(gucGorseli != null) gucGorseli.SetActive(false);
        if(cevGorseli != null) cevGorseli.SetActive(false);
        if(dayGorseli != null) dayGorseli.SetActive(false);
        if(zekGorseli != null) zekGorseli.SetActive(false);
        if(karGorseli != null) karGorseli.SetActive(false);
        buyuDoğru=0;
        GetComponent<Image>().sprite = newImage;
    }
}
