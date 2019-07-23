using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManageMentControll : MonoBehaviour
{
    private int NoofGlassesTouchedTable=0;
    private GlassManageMent mglassmanager;
    private GuideManager mguidemanager;

    private bool isLevelcompleted;
    // Start is called before the first frame update
    private int Initialvalue;

    private bool IsGlassisAdded;
    void Start()
    {
        mglassmanager = FindObjectOfType<GlassManageMent>();
        mguidemanager = FindObjectOfType<GuideManager>();
    }

    private void GetlevelStatus()
    {
       if( checkMatchGlases())
        {
            StartCoroutine(WaitsomeTime());
        }
        
    }
    IEnumerator WaitsomeTime()
    {
        yield return new WaitForSeconds(0.5f);
        if(checkMatchGlases())
        {
            FindObjectOfType<PanelControlS>().SetLevelCompletMenu();

           
            Debug.Log("level is COmpleted");
            setGameLevelIsCompelted();
        }
    }
    private bool checkMatchGlases()
    {
       // return (mglassmanager.getNotofGlassesActive() - 1) == mglassmanager.noofLevelGlasses();
        return (mglassmanager.noofLevelGlasses() == mglassmanager.GetnoofProperGlasses());
    }


    // Update is called once per frame
    void Update()
    {
        GetlevelStatus();
    }


   private void setGameLevelIsCompelted()
    {
        isLevelcompleted = true;
    }
    public bool getLevelCompletestatus()
    {
        return isLevelcompleted;
    }
    public void SetGlassisAdded(bool value)
    {
        IsGlassisAdded = value;
    }
    public bool GetIsGlassIsAdded()
    {
        return IsGlassisAdded;
    }


    
 
}
