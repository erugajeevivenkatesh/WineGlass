using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarControlScript : MonoBehaviour
{

  [SerializeField]  private List<Image> stars = new List<Image>(); 
    [SerializeField] private Color starColor;
    [SerializeField] private Color nostarColor;

    // Start is called before the first frame update
    void Start()
    {
        setstarpannel();
    }

    private void setstarpannel()
    {
       if( FindObjectOfType<NoofGlassesUsed>().GetnoOfGlasses()<=1)
        {
            stars[0].color = starColor;
            stars[1].color = nostarColor;
            stars[2].color = nostarColor;
            setAlpa();
        }

       else if (FindObjectOfType<NoofGlassesUsed>().GetnoOfGlasses() == 2)
        {
            stars[0].color = starColor;
            stars[1].color = starColor;
            stars[2].color = nostarColor;
            setAlpa();
        }
       else if (FindObjectOfType<NoofGlassesUsed>().GetnoOfGlasses() == 3)
        {
            stars[0].color = starColor;
            stars[1].color = starColor;
            stars[2].color = starColor;
            setAlpa();
        }

    }

    private  void setAlpa()
    {

        foreach(Image m in stars)
        {
            var tempcolor = m.color;
            tempcolor.a = 1f;
            m.color = tempcolor;
            
        }
    }
    

   
}
