using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftandRightDetection : MonoBehaviour
{
    private bool runOnlyOnce;
    private bool runOnlyOncesecond;
    private bool OneisActive;

    private GlassManageMent mglassManagement;
    private GameManageMentControll mglassManagementcontroll;

    public CheckDetections mcheckdetection;

    private void Awake()
    {
        mglassManagement = FindObjectOfType<GlassManageMent>();
        mglassManagementcontroll = FindObjectOfType<GameManageMentControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            if (!runOnlyOnce)
            {
                if (!OneisActive)
                {
                    OneisActive = true;
                    
                    mglassManagement.AddAnotherGlass();

                    Deleteifadded();
                    runOnlyOnce = true;
                    Destroy(transform.parent.gameObject, 0.05f);
                    mcheckdetection.stopingallcorotines();
                    //  setrechek();
                    Debug.Log("Detected table");


                }
            }
        }
        if (collision.gameObject.CompareTag("TopDetection"))
        {
            if (!runOnlyOncesecond)
            {
                if (!OneisActive)
                {
                    OneisActive = true;
                  
                    mglassManagement.AddAnotherGlass();


                    Deleteifadded();
                    runOnlyOncesecond = true;
                    mcheckdetection.stopingallcorotines();
                    Destroy(transform.parent.gameObject, 0.05f);
                    Debug.Log("Detected Top Detection");
                   
                }
            }
        }
    }

    private void Deleteifadded()
    {
        if(mglassManagementcontroll.GetIsGlassIsAdded())
        {
            Debug.Log("Glass  is reduced");
            FindObjectOfType<GlassManageMent>().DeceaseProperNoofGlassesActive();
            FindObjectOfType<CreateDimentions>().ActivePerticulerGuide();
            mglassManagementcontroll.SetGlassisAdded(false);
        }
    }
    
}
