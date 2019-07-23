using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRayCastDetection : MonoBehaviour
{
    [SerializeField] private float raycastDistace = 5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SecondRayCastStatus();
        raycastDistace = FindObjectOfType<GlassManageMent>().GetRaycastDistance();
    }

    public bool SecondRayCastStatus()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, raycastDistace);
        Debug.DrawRay(transform.position, transform.right * raycastDistace, Color.green);
        if (raycastHit.collider != null)
        {

          
            if (raycastHit.collider.gameObject.tag == "Glass")
            {
                return true;
             //   Debug.Log(raycastHit.collider.gameObject.tag);
              //  FindObjectOfType<SpawnGlassScript>().moveUpposition();
            }
            else
            {
                return false;
            }
        }
        return false;

    }
}
