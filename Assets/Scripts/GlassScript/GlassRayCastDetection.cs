using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRayCastDetection : MonoBehaviour
{

 


    [SerializeField]private float RaycastDisance = 5f;

    private SecondRayCastDetection msecondraycast;
    private int StepsMove;
    private bool isStartedMoving;
    private GlassManageMent mGlassManageMent;
    private void Awake()
    {
        mGlassManageMent = FindObjectOfType<GlassManageMent>();
        msecondraycast = FindObjectOfType<SecondRayCastDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHitDetection();
        RaycastDisance = mGlassManageMent.GetRaycastDistance();
    }

    private void RaycastHitDetection()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, RaycastDisance);
        Debug.DrawRay(transform.position, transform.right*RaycastDisance, Color.green);
        if (raycastHit.collider != null)
        {
         
            if (raycastHit.collider.gameObject.tag == "Glass" && msecondraycast.SecondRayCastStatus())
            {
                mGlassManageMent.SetStepMove(1);//inncrease step move upwards
                Debug.Log("stepis Increased");
        
               FindObjectOfType<SpawnGlassScript>().moveUpposition(0.5f);
            }

            else
            {
                
                if (mGlassManageMent.GetstepMove() > 0)
                {


                    mGlassManageMent.SetStepMove(-1);
                    Debug.Log("one step deccreased"+StepsMove);
                    FindObjectOfType<SpawnGlassScript>().MoveDownPosition(0.5f);

                }
            }
        }
        
    }

    
 


}
