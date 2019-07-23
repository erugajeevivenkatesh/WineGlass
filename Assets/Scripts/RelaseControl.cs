using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RelaseControl : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //relesed controled with touch pointer


    private GlassManageMent mglassmanager;
    private bool isReleased;
    private bool CallonlyOnce;

    private void Awake()
    {
        mglassmanager = FindObjectOfType<GlassManageMent>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isReleased = true;
        mglassmanager.HintActivator(false);
    }

    public void OnPointerUp(PointerEventData eventData)

    {
        isReleased = false;

        if (!CallonlyOnce)
        {
            StartCoroutine(WaitandCallGlass());

        }
        

    }
    private void Update()
    {
     //   TouchManager();
    }



    public bool  GetTapstatus()
    {
        return isReleased;
    }

    IEnumerator WaitandCallGlass()
    {
        CallonlyOnce = true;
        yield return new WaitForSeconds(1f);
            mglassmanager.ReleaseGlassObeject();
        CallonlyOnce = false;

    }
   private void TouchManager()
    {

       
        if(Input.touchCount>0)
        {
           
          
            Touch m_touch = Input.GetTouch(0);

            if (m_touch.phase == TouchPhase.Moved)
            {

                //Vector2 pos = m_touch.position;
                Vector2 pos = Camera.main.ScreenToWorldPoint(m_touch.position);


                Debug.Log(pos);
                //pos.x = (pos.x - width) / width;
            //  position = new Vector2(pos.x, transform.position.y);

             //   moveTowardstouch(position);
            }
        }
    }


}







