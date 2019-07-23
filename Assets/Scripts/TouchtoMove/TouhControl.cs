using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouhControl : MonoBehaviour
{


    private Vector2 mNextposition;
   
    private float movespeed = 30f;

    private float releasespeed = 1f;
    private bool IsTouched;
    private bool isReleased;



    private float min_x;
    private float max_x;




    private SpawnGlassScript mspawnControl;
    private GlassManageMent mglassmanager;
    
    private void Awake()
    {
        mglassmanager = FindObjectOfType<GlassManageMent>();
        mspawnControl = FindObjectOfType<SpawnGlassScript>();
    }
    private void Start()
    {
        mglassmanager = FindObjectOfType<GlassManageMent>();
        CaluculateBoundrysize();
    }

    private void CaluculateBoundrysize()
    {
        min_x = -mglassmanager.Boundrysize()/2;
        max_x = mglassmanager.Boundrysize() / 2;
    }


    void Update()
    {
        TouchManager();
       // Debug.Log("releasestatus--------" + GetTouchandReleaseStatus());
    }

    private void TouchManager()
    {


        if (Input.touchCount > 0)
        {

            IsTouched = true;
            Touch m_touch = Input.GetTouch(0);

            if (m_touch.phase == TouchPhase.Moved)
            {

                //Vector2 pos = m_touch.position;
                Vector2 pos = Camera.main.ScreenToWorldPoint(m_touch.position);

              //  Debug.Log(pos);
                //pos.x = (pos.x - width) / width;           
                mspawnControl.MoveTowardsPointer(CheckBoundries(pos));
            }
        }
        else
        {
            if(IsTouched)
            {
                SetTouchandReleasestatus(IsTouched);
                IsTouched = false;
                mglassmanager.HintActivator(false);
              //  mglassmanager.CallRayIdentifier();
            //    StartCoroutine(WaitForAnotherGlasssRealease());
            }
        }


    }

    private Vector2 CheckBoundries(Vector2 pos)
    {
        Vector2 temppos = pos;
           if(temppos.x >max_x)
        {
            temppos.x = max_x;
        }
           else if(temppos.x<min_x)
        {
            temppos.x = min_x;
        }

        return pos = temppos;
    }



    public bool GetTouchandReleaseStatus()
    {

        return isReleased; 
    }

    public void SetTouchandReleasestatus(bool value)
    {

      //  Debug.Log("Before release status " + GetTouchandReleaseStatus());
        isReleased = value;
     //   Debug.Log("after release status" + GetTouchandReleaseStatus());
       
    }

    public void askAnotherglass()
    {
        StartCoroutine(WaitForAnotherGlasssRealease());
    }

    

    IEnumerator WaitForAnotherGlasssRealease()
    {
       // CallonlyOnce = true;
        yield return new WaitForSeconds(releasespeed);
        mglassmanager.ReleaseGlassObeject();

      //  CallonlyOnce = false;

    }




}
