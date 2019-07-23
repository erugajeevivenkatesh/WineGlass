using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//releasing glass based on no of steps in the game 
//active and deactive droup guide inthe this game
public class GlassManageMent : MonoBehaviour
{

    public GameObject Glassprefab;
    [SerializeField] private int Noofsteps;
    private int NoofGlasses = 0;
    [SerializeField] private GameObject Hint;
    [SerializeField] private GameObject PlayerHitGlass;
    private bool callonlyOnce;


     private float RaycastDistance=0;
    private float DefaultRaycastDistance=5;
    private int Stepmove;
    [Header("NoofGlasesActive")]


   [SerializeField] private int NoofProperglasesactive;
    [SerializeField] private int NoOfGlassesActive;
  

    private RelaseControl mreleasecontrol;
    private void Awake()
    {
        mreleasecontrol = FindObjectOfType<RelaseControl>();      
    }
    void Start()
    {
     
        HintActivator(false);
        NoofGlasses =totalglasses(Noofsteps);
        ReleaseGlassObeject();
    }



    public int noofLevelGlasses()
    {
        return totalglasses(Noofsteps);
    }


   
    private int totalglasses(int value)
    {
        int sum = 0;
        while(value>=0)
        {
            sum = sum + value;
            value--;
        }
        
        return sum;
    }
    private void Update()
    {
        CheckDetection();
    }

    public void ReleaseGlassObeject()
    {
       if (NoofGlasses >= 0)
      {
            
                HintActivator(true);
                var mglass = Instantiate(Glassprefab, transform.position, Quaternion.identity);
                mglass.transform.parent = transform.parent;
                NoofGlasses--;
            
       }
       else
       {
            //  int currentlevel = SceneManager.GetActiveScene().buildIndex;
            //  SceneManager.LoadScene(currentlevel);
       }
    }

    
    public void setnoofProperGlassesAlive()
    {
        NoofProperglasesactive++;
        FindObjectOfType<SpawnGlassScript>().checkandmove();
    }
    public int GetnoofProperGlasses()
    {
        return NoofProperglasesactive;
    }


    public void DeceaseProperNoofGlassesActive()
    {
        if(NoofProperglasesactive>0)
        {
            NoofProperglasesactive--;
        }
    }
    public void AddAnotherGlass()
    {
        FindObjectOfType<NoofGlassesUsed>().CheckGameOver();//decreasing the glasses and check the game over
        NoofGlasses ++ ;
    }

    public void HintActivator(bool value)
    {
        Hint.SetActive(value);
    }

    public float Boundrysize()
    {
        return Glassprefab.GetComponent<Renderer>().bounds.size.x*(Noofsteps);
    }

    private void UpdateStepDistance()
    {
     //   getNotofGlassesActive();// get no of glasses active in game play   
    }

    private void CheckDetection()
    {
        //forspawning();
       // forTouchSpawning();
    }
    private void forspawning()
    {


        if (FindObjectOfType<TouhControl>() != null)
        {
            if (FindObjectOfType<TouhControl>().GetTouchandReleaseStatus())
            {
                if (!callonlyOnce)
                {
                    StartCoroutine(Waitsometime());
                }
            }

        }
    }
    private void forTouchSpawning()
    {

        if (FindObjectOfType<TouhControl>() != null)
        {
            if (FindObjectOfType<TouhControl>().GetTouchandReleaseStatus())
            {
                if (!callonlyOnce)
                {
                    StartCoroutine(Waitsometime());
                }
            }

        }
    }


    public void CallRayIdentifier()
    {
      //  StartCoroutine(Waitsometime());
    }

    IEnumerator Waitsometime()
    {
        callonlyOnce = true;
        setRaycastDistance(0f);
        yield return new WaitForSeconds(1f);
        {
            setRaycastDistance(DefaultRaycastDistance);
            callonlyOnce = false;
        }
    }

    public void SetStepMove(int value)
    {
        Stepmove=+value;
    }
    public int GetstepMove()
    {
        return Stepmove;
    }

    public void setRaycastDistance(float value)
    {
        RaycastDistance = value;    
    }
    public float GetRaycastDistance()
    {
        return RaycastDistance;
    }


 


    public int getnoOfSteps()
    {
        return Noofsteps;
    }



  
  
}
