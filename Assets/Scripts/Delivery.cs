using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 packageColor1 = new Color32(1,1,1,1);
    [SerializeField] Color32 packageColor2 = new Color32(1,1,1,1);
    [SerializeField] Color32 packageColor3 = new Color32(1,1,1,1);

    [SerializeField] float destroyDelay = 0.2f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Color")
        {
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
        }
    }
}
