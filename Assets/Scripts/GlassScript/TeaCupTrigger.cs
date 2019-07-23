using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCupTrigger : MonoBehaviour
{

    private bool runOnlyOnce;
    private bool runonlySecondonce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Triangle"))
        {

            if(!runOnlyOnce)
            {
                Debug.Log("Teaglas triggered with triangle");
             
                runOnlyOnce = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Triangle"))
        {

            if (!runonlySecondonce)
            {
                Debug.Log("Trigger exit");
                runonlySecondonce = true;

            }
        }
    }
}
