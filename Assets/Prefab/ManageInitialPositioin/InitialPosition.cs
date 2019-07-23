using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPosition : MonoBehaviour
{


 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table")) 
        {
            callGuideObejct();
       //     Debug.Log("Table is Triggereed");
          Destroy(gameObject);
        }
    }

    private void callGuideObejct()
    {
        FindObjectOfType<CreateDimentions>().GetRealese(gameObject.transform.position - new Vector3(0.0f,0.05f, 0f));
    }

}
