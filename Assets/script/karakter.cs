using UnityEngine;
using System.Collections.Generic;

using UnityEngine.UI;

[System.Serializable]
public class KarakterData
{
     public float beklemesüresi=0f;
    public string karakterIsmi;
    public string istenenBuyu;

    [Header("spritelar")]
    public Sprite gorsel0;
    public Sprite gorsel1;
    public Sprite gorsel2;
    [Header("animasyon")]
    public GameObject dogruanim;
    public GameObject yanlisanim;
    [Header("nesne")]
    public Sprite getirilenEsya;

}

public class karakter : MonoBehaviour
{
    [Header("karakter sırası")]
    public List<KarakterData>gelenKarakterler;
    private int aktifKarakterIndex=0;

    [Header("karakter ihtiyacı")]
    public int guc;
    public int ceviklik;
    public int dayaniklilik;
    public int zeka;
    public int karizma;

    [Header("Oyun Durumu")]
    public bool buyuVerildi=false;
    public GameObject karakterGörseli0;
    public GameObject karakterGörseli1;
    public GameObject karakterGörseli2;
    public ıtem item;

    [Header("Sistem Referansları")]
    public AnimationZone animZone;
    private WalkTo yürümeScripti;
   

    void Awake()
    {
        yürümeScripti=GetComponent<WalkTo>();
    }

    void Start()
    {
        KarakteriYukle(aktifKarakterIndex);
    }
    void Update()
    {
        if (item.buyuDoğru == 0)
        {
            karakterGörseli0.SetActive(true);
            karakterGörseli1.SetActive(false);
            karakterGörseli2.SetActive(false);
        }
        else if (item.buyuDoğru == 1)
        {
            karakterGörseli0.SetActive(false);
            karakterGörseli1.SetActive(true);
            karakterGörseli2.SetActive(false);
        }
        else
        {
            karakterGörseli0.SetActive(false);
            karakterGörseli1.SetActive(false);
            karakterGörseli2.SetActive(true);
        }
    }

    public void KarakteriGonder()
    {
        if (buyuVerildi == true)
        {
            if (yürümeScripti != null)
            {
                yürümeScripti.GoBack();
            }
        }
        else Debug.Log("buyu verilmedi gidemem");
    }

    public void SiradakiKaraktereGec()
    {
        aktifKarakterIndex++;
        if (aktifKarakterIndex < gelenKarakterler.Count)
        {
            KarakteriYukle(aktifKarakterIndex);
            yürümeScripti.ResetPositionAndWalk();
        }
        
    }

    private void KarakteriYukle(int index)
    {
        KarakterData siradaki=gelenKarakterler[index];
        item.istenenBuyu=siradaki.istenenBuyu;

        karakterGörseli0.GetComponent<Image>().sprite= siradaki.gorsel0;
        karakterGörseli1.GetComponent<Image>().sprite= siradaki.gorsel1;
        karakterGörseli2.GetComponent<Image>().sprite= siradaki.gorsel2;

        animZone.dogruBuyuAnimasyonu=siradaki.dogruanim;
        animZone.yanlisBuyuAnimasyonu=siradaki.yanlisanim;

        item.EsyayıSifirla(siradaki.getirilenEsya);

        buyuVerildi=false;
        item.buyuDoğru=0;
    }
}
