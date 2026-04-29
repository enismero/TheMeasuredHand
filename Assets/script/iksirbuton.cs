using UnityEngine;

public class iksirbuton : MonoBehaviour
{
    public ıtem gelenNesne;
    
    public void ButtonClick(string statName)
    {
       gelenNesne.statArttir(statName);
       gelenNesne.BuyuDene(statName);
    }
    
}
