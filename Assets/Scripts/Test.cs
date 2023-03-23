using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    void Start()
    { }
    RaycastHit2D HIT;


    void Update()
    { 
        HIT =  Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), transform.forward,1500);
        Debug.Log(" HIt "+(HIT.collider != null));
        if(HIT.collider != null && HIT.collider.gameObject.CompareTag("CARDS"))
        {
            HIT.collider.gameObject.transform.Rotate(HIT.collider.gameObject.transform.rotation.eulerAngles + (Vector3.forward * 180));
        }
    }
     
     private void OnMouseEnter() {
        HIT =  Physics2D.Raycast(Input.mousePosition, transform.forward,1500);
        Debug.Log(" HIt "+(HIT.collider != null));
        if(HIT.collider.gameObject.CompareTag("CARDS"))
        {
            HIT.collider.gameObject.transform.Rotate(HIT.collider.gameObject.transform.rotation.eulerAngles + (Vector3.forward * 180));
        }
        OnMouseDown();
     }
     private void OnMouseDown() {
        
     }
     
}
