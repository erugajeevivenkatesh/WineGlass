using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecknoOfGlassesTriggered : MonoBehaviour
{
    private int noOFGlassesintrigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Glass"))
        {
            if (FindObjectOfType<RelaseControl>().GetTapstatus())
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
    }
   
}
