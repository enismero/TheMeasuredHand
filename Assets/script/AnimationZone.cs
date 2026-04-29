using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("ana panel")]
    public GameObject animasyonPaneli;
    public hand handDurum;
    public ıtem item;
    public hand akil;

    [Header("thor anim")]
    public GameObject dogruBuyuAnimasyonu;  
    public GameObject yanlisBuyuAnimasyonu;

    public bool gameİs=true;

    void Start()
    {
        if (animasyonPaneli != null) 
        {
            animasyonPaneli.SetActive(false);
            
            if(akil.akilSağliği==100)
            {
                handDurum.handKapali0.SetActive(true);
              //  handDurum.handKapali1.SetActive(false);
                handDurum.handKapali2.SetActive(false);
                handDurum.handKapali3.SetActive(false);
            } 
            else if(akil.akilSağliği==75)
            {
                 handDurum.handKapali0.SetActive(false);
                //  handDurum.handKapali1.SetActive(true);
                  handDurum.handKapali2.SetActive(true);
                  handDurum.handKapali3.SetActive(false);
            }
            else if(akil.akilSağliği==50)
            {
                 handDurum.handKapali0.SetActive(false);
                //  handDurum.handKapali1.SetActive(false);
                  handDurum.handKapali2.SetActive(false);
                  handDurum.handKapali3.SetActive(true);
            }
            else if(akil.akilSağliği==25)
            {
                gameİs=false;
            }
            
            handDurum.handAçik0.SetActive(false);
          //  handDurum.handAçik1.SetActive(false);
            handDurum.handAçik2.SetActive(false);
            handDurum.handAçik3.SetActive(false);
            
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animasyonPaneli != null) 
        {
            animasyonPaneli.SetActive(true); //anapanel


            handDurum.handKapali0.SetActive(false);
           // handDurum.handKapali1.SetActive(false);
            handDurum.handKapali2.SetActive(false);
            handDurum.handKapali3.SetActive(false);

            if(akil.akilSağliği==100)
            {
                handDurum.handAçik0.SetActive(true);
              //  handDurum.handAçik1.SetActive(false);
                handDurum.handAçik2.SetActive(false);
                handDurum.handAçik3.SetActive(false);
            } 
            else if(akil.akilSağliği==75)
            {
                 handDurum.handAçik0.SetActive(false);
                 // handDurum.handAçik1.SetActive(true);
                  handDurum.handAçik2.SetActive(true);
                  handDurum.handAçik3.SetActive(false);
            }
            else if(akil.akilSağliği==50)
            {
                 handDurum.handAçik0.SetActive(false);
                 // handDurum.handAçik1.SetActive(false);
                  handDurum.handAçik2.SetActive(false);
                  handDurum.handAçik3.SetActive(true);
            }
            else if(akil.akilSağliği==25)
            {
                gameİs=false;
            }
            //handDurum.handAçik.SetActive(true);
            

            if(item.buyuDoğru==0 || item.buyuDoğru == 2)
            {
                yanlisBuyuAnimasyonu.SetActive(true);
                dogruBuyuAnimasyonu.SetActive(false);
            }
            else if (item.buyuDoğru == 1)
            {
                yanlisBuyuAnimasyonu.SetActive(false);
                dogruBuyuAnimasyonu.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animasyonPaneli != null) 
        {
        
        if(akil.akilSağliği==100)
            {
                handDurum.handKapali0.SetActive(true);
                //handDurum.handKapali1.SetActive(false);
                handDurum.handKapali2.SetActive(false);
                handDurum.handKapali3.SetActive(false);
            } 
            else if(akil.akilSağliği==75)
            {
                 handDurum.handKapali0.SetActive(false);
                 // handDurum.handKapali1.SetActive(true);
                  handDurum.handKapali2.SetActive(true);
                  handDurum.handKapali3.SetActive(false);
            }
            else if(akil.akilSağliği==50)
            {
                 handDurum.handKapali0.SetActive(false);
                 // handDurum.handKapali1.SetActive(false);
                  handDurum.handKapali2.SetActive(false);
                  handDurum.handKapali3.SetActive(true);
            }
            else if(akil.akilSağliği==25)
            {
                gameİs=false;
            }

        handDurum.handAçik0.SetActive(false);
       // handDurum.handAçik1.SetActive(false);
        handDurum.handAçik2.SetActive(false);
        handDurum.handAçik3.SetActive(false);

        animasyonPaneli.SetActive(false);
        }
    }
}
