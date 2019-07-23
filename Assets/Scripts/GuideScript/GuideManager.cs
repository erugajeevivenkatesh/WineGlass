using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour
{

   [SerializeField] private int NoofGlassespositioned;
    private bool recheckall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddedLevelGalss()
    {
        NoofGlassespositioned++;
    }
    public void DecreaseLevelGlass()
    {
        if (NoofGlassespositioned <= 0)
        {
            return;
        }
        NoofGlassespositioned--;
        setrecheck(false);
    }
    public void setNoofGlassapointed()
    {
        recheckall = false;
        NoofGlassespositioned = 0;
    }

    public int  getActivelyPlaced()
    {
        return NoofGlassespositioned;
    }
    public bool getRecheck()
    {
        return recheckall;
    }
    public void setrecheck(bool value)
    {
        recheckall = value;
       
    }
}
