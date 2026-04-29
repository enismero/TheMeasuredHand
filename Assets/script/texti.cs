using UnityEngine;
using TMPro;
using System.Collections;

public class texti : MonoBehaviour
{
    public static texti Instance;

    [Header("Dialogue Settings")]
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;

    [Header("Message")]
    [TextArea(5, 20)] 
    public string fullMessage;
    public float silinmeSuresi = 2f;
    public float baslangicGecikmesi = 1.5f;

    //private bool isTyping = false;
    private Coroutine typingCoroutine;
    void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void OnEnable()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(fullMessage));
    }
    private IEnumerator TypeText(string textToType)
    {
        //isTyping = true;
        dialogueText.text = "";
        yield return new WaitForSeconds(baslangicGecikmesi);

        foreach (char letter in textToType.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        //isTyping = false;
        yield return new WaitForSeconds(silinmeSuresi);

        Destroy(gameObject);
    }

}
