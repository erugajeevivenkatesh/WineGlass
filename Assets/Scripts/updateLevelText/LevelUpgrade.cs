using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelUpgrade : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI LevelText;

    // Start is called before the first frame update
    void Start()
    {
        LevelText.text = (FindObjectOfType<PanelControlS>().getCurrentLevel()+1).ToString();
    }
    
}
