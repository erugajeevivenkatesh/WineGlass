using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRelease : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D mrigidbody;
    public GameObject releasedGlasspostion;

    private RelaseControl mrelease;
    private TouhControl TouchRelease;

    private bool CallOnlyOnce;

    private void Awake()
    {
        mrelease = FindObjectOfType<RelaseControl>();
        TouchRelease = FindObjectOfType<TouhControl>();
    }
    void Start()
    {
        if(TouchRelease!=null)TouchRelease.SetTouchandReleasestatus(false);
    //    FindObjectOfType<GlassManageMent>().setNoofGlassesActive();
        mrigidbody = GetComponent<Rigidbody2D>();
        mrigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!CallOnlyOnce)
        {
            ReleaseKinamatic();
        }
    }


    private void ReleaseKinamatic()
    {
        
        if (mrelease!=null)//mrelease != null||
        {
            
          //  Debug.Log("release status---->" +TouchRelease.GetTouchandReleaseStatus());//mrelease.GetTapstatus()
         //   if (FindObjectOfType<TouhControl>().GetTouchandReleaseStatus())
            if (mrelease.GetTapstatus())
            {
                    CallOnlyOnce = true;
                     Debug.Log("kinamatice is false");
                    
                    mrigidbody.isKinematic = false;
                    transform.parent = releasedGlasspostion.transform.parent;
              //  FindObjectOfType<TouhControl>().SetTouchandReleasestatus(false);
               // FindObjectOfType<TouhControl>().askAnotherglass();

                
            }
       }
    }

    
    private void RemoveGlass()
    {
        FindObjectOfType<GlassManageMent>().AddAnotherGlass();
        //removeglasss
    }

    
  
}
