using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitCanvas2to3 : StateMachineBehaviour
{
    public GameObject imgL;
    public GameObject imgR;
    
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        imgL.GetComponent<Animator>().enabled = true;
        imgR.GetComponent<Animator>().enabled = true;    
    }

    
}
