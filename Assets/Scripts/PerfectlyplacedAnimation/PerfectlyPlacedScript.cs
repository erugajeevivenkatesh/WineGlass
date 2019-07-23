using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectlyPlacedScript : MonoBehaviour
{
   

   public void CallDeactivePerfectlyPlaced()
    {
        Destroy(transform.parent.gameObject);
    }
       
}
