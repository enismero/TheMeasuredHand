using UnityEngine;
using UnityEngine.InputSystem;


public class hand : MonoBehaviour
{
    [Header("core mechanic")]
    public int akilSağliği=100;
    public GameObject handKapali0;
    public GameObject handKapali1;
    public GameObject handKapali2;
    public GameObject handKapali3;
    public GameObject handAçik0;
    public GameObject handAçik1;
    public GameObject handAçik2;
    public GameObject handAçik3;
    private CanvasGroup canvasGroup;


    void Awake()
    {
        canvasGroup= GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup=gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.blocksRaycasts=false;
    }
    void Update()
    {
        if (Mouse.current != null)
        transform.position = Mouse.current.position.ReadValue();
    }

}
