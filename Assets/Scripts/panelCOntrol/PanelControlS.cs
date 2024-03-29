using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelControlS : MonoBehaviour
{

    [SerializeField] private GameObject MainmenuPanel;
    [SerializeField] private GameObject GameOvePanel;

    [SerializeField] private GameObject LevelComplete;
    [SerializeField] private GameObject GameHint;
    [SerializeField] private GameObject TouchControlPanel;

    [SerializeField] private GameObject perfectlyplacedTextPanel;
    [SerializeField] private GameObject particelEffect;

    private bool RunOnlyOnce;



    // Start is called before the first frame update
    void Start()
    {


        perfectlyplacedTextPanel.SetActive(false);
        GameStarted();
        if (getCurrentLevel() == 0) 
        {
            
            SetMenuLevel();
        }
        else
        {
            setPlaygameScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void setPlaygameScene()
    {

        if(getCurrentLevel()==0)
        {
            MainmenuPanel.SetActive(false);
            GameOvePanel.SetActive(false);
            GameHint.SetActive(true);
            LevelComplete.SetActive(false);
            TouchControlPanel.SetActive(false);
        }
        else
        {
            HintDisable();
        }
     

    }

    public void  SetGameOverMenu()
    {
        //  Debug.Log("Game Over");
        GameOverStatistics();
        GameOvePanel.SetActive(true);
        MainmenuPanel.SetActive(false);
        GameHint.SetActive(false);
        LevelComplete.SetActive(false);
        TouchControlPanel.SetActive(false);

    }
    public void  SetLevelCompletMenu()
    {
        MainmenuPanel.SetActive(false);
        GameOvePanel.SetActive(false);
        LevelComplete.SetActive(true);
        GameHint.SetActive(false);
        TouchControlPanel.SetActive(false);
        LevelCompletestatistics();
    }
    public void SetMenuLevel()
    {
        MainmenuPanel.SetActive(true);
        GameOvePanel.SetActive(false);
        LevelComplete.SetActive(false);
        GameHint.SetActive(false);
        TouchControlPanel.SetActive(false);
    }

    public void HintDisable()
    {

        GameHint.SetActive(false);
        TouchControlPanel.SetActive(true);

    }
   

    public void RetryGame()
    {
      
        SceneManager.LoadScene(getCurrentLevel());
    }

    public int getCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(getCurrentLevel() + 1);  
    }

    public void SetperfectlyPlacedText(GameObject mgameobj)
    {

    var PerfectGameObejct=    Instantiate(perfectlyplacedTextPanel, mgameobj.transform.position, Quaternion.identity);
        Instantiate(particelEffect, mgameobj.transform.position, Quaternion.identity);
        if  (!PerfectGameObejct.activeInHierarchy)
        {
            PerfectGameObejct.SetActive(true);
        }

    }

    private void GameStarted()
    {
     
            Debug.Log("Game started --- Current level is---> " +( getCurrentLevel()+1));

    }

    private void GameOverStatistics()
    {

        if (!RunOnlyOnce)
        {
            RunOnlyOnce = !RunOnlyOnce;
            Debug.Log("Game Over ----Current level--->" + (getCurrentLevel()+1));
        }
    }
    private  void LevelCompletestatistics()
    {
        if (!RunOnlyOnce)
        {
            RunOnlyOnce = !RunOnlyOnce;
            Debug.Log("Level is Completed----->" + (getCurrentLevel()+1));
          
        }
    }




}
