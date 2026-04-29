using UnityEngine;
using TMPro;
using System.Collections;

public class bekeleme : MonoBehaviour
{
   public float beklemesüresi=30f;
   private IEnumerator TypeText(string textToType)
    {
        
      

       

       
        yield return new WaitForSeconds(beklemesüresi);

        Destroy(gameObject);
    }
}
