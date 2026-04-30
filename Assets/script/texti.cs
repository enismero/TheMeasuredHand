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
    public string[] messages;
    public float cümlearasibekleme = 2f;
    public float baslangicGecikmesi = 1.5f;
    public bool isTyping=true;

    
    private Coroutine typingCoroutine;
    void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void OnEnable()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeAllMessages());
    }
    private IEnumerator TypeAllMessages()
    {
        
        dialogueText.text = "";
        yield return new WaitForSeconds(baslangicGecikmesi);

        foreach (string sentence in messages)
        {
            dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray())
            {
                dialogueText.text+=letter;
                yield return new WaitForSeconds(typingSpeed);
            }
                yield return new WaitForSeconds(cümlearasibekleme);
        }
        isTyping=false;
        
        //gameObject.SetActive(false);
        
    }

    public Animator anim;
    void Update()
    {
        anim.SetBool("start",isTyping);
    }

}
