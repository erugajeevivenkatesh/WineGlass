using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDimentions : MonoBehaviour
{


    [SerializeField]  private GameObject guide;

   [SerializeField ]private int noofsteps;
   [SerializeField] private GameObject parentGabeject;

    private List<GameObject> mlistgameobject;

    private List<GameObject> mListofGuidesactiveordeactive;


    

    private bool runonlyonce;
    private int count = 0;
    private Vector2 nextposition;
    private Vector2 initialposition;

    private Vector2 StartPostion;

    private int Count=0;

    private void Awake()
    {
        mlistgameobject=new List<GameObject>();

        mListofGuidesactiveordeactive = new List<GameObject>();

        initialposition = transform.position;
        nextposition = initialposition;
    }
    private void Start()
    {
        noofsteps = FindObjectOfType<GlassManageMent>().getnoOfSteps();

    }

    public void updateInitialPosition(Vector2 position)//update initial position
    {
        StartPostion = position;
    }
    




    public void GetRealese(Vector2 CurrentPositon)
    {
        nextposition = CurrentPositon;
        if(mlistgameobject!=null)
        {
            mlistgameobject.Clear();
        }
        if(mListofGuidesactiveordeactive!=null)
        {
          mListofGuidesactiveordeactive.Clear();
        }
       
        while (noofsteps > 0)
        {

            for (int i = 0; i < noofsteps; i++)
            {
                Instasiategameobejct(nextposition);

                Updatenextpositionalongx(nextposition, getboundrysizealongx());
            }

            nextposition = mlistgameobject[0].transform.position;
            updatenextpostiony(nextposition);
            Updatenextpositionalongx(nextposition, getboundrysizealongx()/2);
            mlistgameobject.Clear();

            noofsteps--;
        }
        foreach(GameObject obj in mListofGuidesactiveordeactive)
        {
            obj.SetActive(false);
        }
        if (mListofGuidesactiveordeactive != null)
            ActivePerticulerGuide();
    }
    private void Instasiategameobejct(Vector2 InstansiatePosition)
    {
        var gameobj = Instantiate(guide, InstansiatePosition, Quaternion.identity);
        gameobj.transform.parent = parentGabeject.transform;
        mlistgameobject.Add(gameobj);

        mListofGuidesactiveordeactive.Add(gameobj);//adding list of guides       
    }


    public List<GameObject> ActiveGuides()
    {

        return mListofGuidesactiveordeactive;

    }
    


    public void SetBoxGuideDeactive(GameObject mboxguide)
    {
        mboxguide.SetActive(false);
    }

    private void Updatenextpositionalongx(Vector2 nextpositon,float boudrysize)
    {
     
     Vector2 nextpos = nextpositon;
        nextpos.x = nextpos.x + boudrysize+0.05f;
        nextposition = nextpos;
    }

    private void updatenextpostiony(Vector2 nextpositon)
    {
        Vector2 nextposy = nextpositon;
        nextposy.y = nextposy.y+ getboudrysizealongy();
        nextposition = nextposy;
    }

    private float getboundrysizealongx()
    {
        return guide.GetComponent<Renderer>().bounds.size.x;
    }
    private float getboudrysizealongy()
    {
        return guide.GetComponent<Renderer>().bounds.size.y;
    }

   public void ActiveAnotherGlass()
    {
        count++;
        if(count<mListofGuidesactiveordeactive.Count)
        {
            mListofGuidesactiveordeactive[count].gameObject.SetActive(true);
        }

    }

    public void ActivePerticulerGuide()
    {
        int activeposition = FindObjectOfType<GlassManageMent>().GetnoofProperGlasses();


        if(activeposition<mListofGuidesactiveordeactive.Count)
        {
            for(int i=0;i< mListofGuidesactiveordeactive.Count;i++)
            {
                if(i==activeposition)
                {
                    mListofGuidesactiveordeactive[i].SetActive(true);
                }
                else
                {
                    mListofGuidesactiveordeactive[i].SetActive(false);

                }
            }
        }

        if (activeposition == mListofGuidesactiveordeactive.Count)
        {
            mListofGuidesactiveordeactive[activeposition - 1].SetActive(false);
        }
    }
}
