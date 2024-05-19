using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasDelivered;
    [SerializeField] int parcelToDisappear;
    [SerializeField] Color32 ToDeliverColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasDelieveredColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("omg");   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Parcel" && !hasDelivered)
        {
            Debug.Log("parcel is picked");
            spriteRenderer.color = ToDeliverColor;
            
            hasDelivered = true;
            Destroy(other.gameObject, parcelToDisappear);
        }
        if(other.tag=="Customer" && hasDelivered)
        {
            Debug.Log("delivered");
            spriteRenderer.color = hasDelieveredColor;
            hasDelivered = false;
        }
    }
}
