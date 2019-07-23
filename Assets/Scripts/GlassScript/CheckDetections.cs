using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDetections : MonoBehaviour
{

   
    // Start is called before the first frame update
    private bool runonlyOnece;  
    private bool runOnlyOncesecond;
    private bool runOnlyOnceforGuide;


    private bool istoucehedpointer;

    private int GlassesCheck;

    private bool isAnythingisTrigger;
    private bool isAddedActiveGlass;

    private bool isproperlyplaced;

    private CreateDimentions mCreateDimestions;
    private GlassManageMent mglassmanagement;
    private GameManageMentControll mgameManagement;
    [SerializeField] private GameObject setGlasstype;


    private bool LevelCompletiOnlyOnce;
    private void Start()
    {
        setGlasstype.SetActive(false);
        //     FindObjectOfType<GuideManager>().setrecheck(false);
        mCreateDimestions = FindObjectOfType<CreateDimentions>();
        mglassmanagement = FindObjectOfType<GlassManageMent>();
        mgameManagement = FindObjectOfType<GameManageMentControll>();
        mgameManagement.SetGlassisAdded(false);
    }


   

    private void Update()
    {


        if (!mgameManagement.getLevelCompletestatus())
        {
            if (!isproperlyplaced)
            {
                if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 0.09f)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                }
            }
        }
        else
        {
            setAllcollidersfalls();

        }    
    }


    private void setAllcollidersfalls()
    {
        if (!LevelCompletiOnlyOnce)
        {
            foreach (Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            LevelCompletiOnlyOnce =! LevelCompletiOnlyOnce;
            setGlasstype.SetActive(true);
        }

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

                if (collision.gameObject.CompareTag("Table"))
                {
                
                    if (!runonlyOnece)
                    {
                     isAnythingisTrigger = true;

                        runonlyOnece = true;
                    }
                }
                if (collision.gameObject.CompareTag("Glass"))
                {
                    if (!runonlyOnece)
                    {
                        isAnythingisTrigger = true;
                        Debug.Log("glass is triggered" + collision.gameObject.tag);
                        runonlyOnece = true;
                    }
                }
                if (collision.gameObject.CompareTag("Triangle"))
                {
                    if (!runOnlyOncesecond)
                    {

                        Debug.Log("Glasss is triggered with triangle");
                        runOnlyOncesecond = true;
                    }
                }

  
        
       



    }

    private void OnTriggerStay2D(Collider2D collision)
    {

      if (CheckVelocity()&&!isproperlyplaced)
       {
            if (isAnythingisTrigger)
            {
                if (collision.gameObject.CompareTag("Guide"))
                {


                    Debug.Log("hit Hit Glass name kinamatic---->" + gameObject.GetComponent<Rigidbody2D>().isKinematic);
                    isAnythingisTrigger = false;
                    Checkagainonce(collision.gameObject);
             //   StartCoroutine(Delaysometimefortrigger(collision.gameObject));


            }
            else
                {
                    StopAllCoroutines();
                    StartCoroutine(Delaysometimefortrigger(collision.gameObject));
                  }
              
            }
        }


    }

    IEnumerator Delaysometimefortrigger(GameObject comparableobejct)
    {
        yield return new WaitForSeconds(0.01f);
        Checkagainonce(comparableobejct);
    }

    private void Checkagainonce(GameObject objex)
    {
        if (!isproperlyplaced)
        {
            if (objex.CompareTag("Guide"))
            {
                if (!runOnlyOnceforGuide)
                {

                    checkdistanceDetection(objex);
                    //  Debug.Log("com in stay");
                    runOnlyOnceforGuide = true;
                }
            }
            else
            {
                Debug.Log("Problem  with placement");
                Setgameover();//start game over
            }
        }
    }


    private void setallreactive()
    {
        runonlyOnece = false;
        runOnlyOncesecond = false;
        runOnlyOnceforGuide = false;


    }



    public bool isaddedpointer()
    {
        return istoucehedpointer;
    }
    private bool checkDetection(GameObject mgame,string check)
    {

        return mgame.CompareTag(check);
    }

   private bool CheckVelocity()
    {
        // Debug.Log("velocity is " + gameObject.GetComponent<Rigidbody2D>().velocity);

        Vector2 mveclocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        
        if (mveclocity==new Vector2(0.0f,0.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    private void checkdistanceDetection(GameObject guideposition)
    {


        Debug.Log("game obeject Boundry size" + guideposition.GetComponent<Renderer>().bounds.size.x);

        float distance = Vector2.Distance(new Vector2(transform.position.x, guideposition.transform.position.y)
            , guideposition.transform.position);

        if (distance < getSizeofshapeguide(guideposition) /6f)
        {

            FindObjectOfType<PanelControlS>().SetperfectlyPlacedText(this.gameObject);
            Debug.Log("perfectly placed");
        }
        if (distance < getSizeofshapeguide(guideposition) / 2f)
        {

            Debug.Log("Distance is---- " + distance);

            updatepositon(new Vector2( guideposition.transform.position.x,transform.position.y));


            DeactivethioneandActiveother(guideposition);
            StopAllCoroutines();
        }
        
        else
        {
            Debug.Log("Distance problem");
           StartCoroutine(waitandcheck());
            
            
        }
    }

    IEnumerator waitandcheck()
    {
        yield return new WaitForSeconds(0.2f);//wait to load game over menu
        Setgameover();
    }

   

    private float getSizeofshapeguide(GameObject shapesize)
    {
        return shapesize.GetComponent<Renderer>().bounds.size.x;

    }


    private void Setgameover()
    {
        FindObjectOfType<PanelControlS>().SetGameOverMenu();//Game Over menu
        Debug.Log("you did not place perticuler");

    }

    private void updatepositon(Vector2 updatepositon)
    {

        Vector2 tempposition = transform.position;
        tempposition = updatepositon;
        transform.position = tempposition;

        isproperlyplaced = true;//set dont check the other objects;
        
    }

    private void DeactivethioneandActiveother(GameObject activeobeject)
    {
    
        mglassmanagement.setnoofProperGlassesAlive();
       

        mCreateDimestions.ActivePerticulerGuide();
        mgameManagement.SetGlassisAdded(true);
        isAddedActiveGlass = true;

        // updateGuide();


    }

    private void updateGuide()
    {
       if( mglassmanagement.GetnoofProperGlasses()==1)
        {
            Debug.Log("calling Again Game Object");
            mCreateDimestions.GetRealese(gameObject.transform.position-new Vector3(0.0f,1f,0f));
            mCreateDimestions.ActivePerticulerGuide();
        }
       else
        {
            mCreateDimestions.ActivePerticulerGuide();
        }

    }

    public bool getIsaddedActiveGlass()
    {
        return isAddedActiveGlass;
    }

    public void stopingallcorotines()

    {
        StopAllCoroutines();
    }


   
    

    
}
