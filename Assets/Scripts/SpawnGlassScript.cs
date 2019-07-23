using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGlassScript : MonoBehaviour
{

    [SerializeField] private GameObject basicStartGuide;
  


    private float mMin_x ;
    private float mMax_x ;
   [SerializeField] private float automovespeed = 2f;
   [SerializeField] private float HorizontalMovespeed = 50f;
    [SerializeField] private int releasedglases = 0;

    
    
    float tempspeed=0f;


    private float boundrysize;
    private GlassManageMent mglassmanagement;

    private int activesteps;
    private int incrementglasse=1;
    private void Awake()
    {
        mglassmanagement = FindObjectOfType<GlassManageMent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ManageBoundry();
        releasedglases = 0;
        tempspeed = automovespeed;
        IntstasiateBasicStartGuide();
        activesteps = mglassmanagement.getnoOfSteps();
    }
    public void ManageBoundry()
    {
        mMin_x = -mglassmanagement.Boundrysize() / 2;
        mMax_x = mglassmanagement.Boundrysize() / 2;
    }
    
    // Update is called once per frame
    void Update()
    {
       // setboundaries();
        spawnGameObeject();
    }
    private void spawnGameObeject()
    {
        Vector2 tempposition = transform.position;
      
        if (tempposition.x > mMax_x)
        {
            tempspeed = -automovespeed;
        }
        else if (tempposition.x < mMin_x)
        {
            tempspeed = automovespeed;
        }
    
        transform.Translate(Vector2.right * Time.deltaTime * tempspeed);
    }



    public void setReleasedGlasses(int value)
    {

        releasedglases = releasedglases + value;
    }
    
    

    public void DamagedReleasedGlass(int value)
    {
        releasedglases = releasedglases - value;
    }

    public void moveUpposition(float value)
    {
        Vector2 tempposition = transform.position;
        tempposition.y = tempposition.y + value;
        transform.position = tempposition;
        
    }
    public void MoveDownPosition(float value)
    {
        Vector2 tempposition = transform.position;
        tempposition.y = tempposition.y - value;
        transform.position = tempposition;
    }

    private void setboundaries()
    {
        Vector2 tempposition = transform.position;
        if(tempposition.x>mMax_x)
        {
            tempposition.x = mMax_x;
        }
        else if(tempposition.x<mMin_x)
        {
            tempposition.x = mMin_x;
        }
        transform.position = tempposition;
    }

    public void MoveTowardsPointer(Vector2 position)
    {
        Vector2 nextposition = new Vector2(position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position,
         nextposition, HorizontalMovespeed * Time.deltaTime);
    }

    private void IntstasiateBasicStartGuide()
    {
        Instantiate(basicStartGuide, new Vector2(mMin_x,transform.position.y), Quaternion.identity);
    }


    public void checkandmove()
    {
        if(incrementglasse> activesteps)
        {
           Debug.Log("steps Moved--" + activesteps);
            activesteps--;
            incrementglasse = 1;
            moveUpposition(basicStartGuide.GetComponent<Renderer>().bounds.size.y);

        }
        else
        {
            Debug.Log("increment steps" + incrementglasse);
            incrementglasse++;
        }
    }
    




   







}
