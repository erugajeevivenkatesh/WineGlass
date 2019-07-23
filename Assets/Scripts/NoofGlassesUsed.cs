
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NoofGlassesUsed : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI availGlasstext;
    private int GlassesLeft = 3;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        UpdateavailGlasstext();
        if (GlassesLeft <= 0)
        {
            FindObjectOfType<PanelControlS>().SetGameOverMenu();

        }
    }
    private void UpdateavailGlasstext()
    {
        availGlasstext.text = "X"+GlassesLeft.ToString();
    }

    public void CheckGameOver()
    {
 
        if (GlassesLeft > 0)
        {
            GlassesLeft--;
        }
    }
    public int GetnoOfGlasses()
    {
        return GlassesLeft;
    }
    
}
