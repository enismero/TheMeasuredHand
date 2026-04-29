using UnityEngine;

public class iksirMovment : MonoBehaviour
{
    [Header("dönüş ayarı")]
    public float hareketHizi=3f;
    public float hareketAçisi=5f;
    public float dönüşHizi=3f;
    public float dönüşAçisi=5f;
    public float x=5f;
    
    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos=transform.localPosition;
        startRot=transform.localRotation;
    }

    void Update()
    {
        float xOffset=Mathf.Sin(Time.time*hareketHizi+x)*hareketAçisi;
        transform.localPosition=startPos + new Vector3(xOffset,0f,0f);

        float zOffset=Mathf.Sin(Time.time*dönüşHizi+x)*dönüşAçisi;
        transform.localRotation=startRot * Quaternion.Euler(0f,0f,zOffset);
    }
}
