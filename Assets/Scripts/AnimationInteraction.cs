using UnityEngine;

class AnimationInteraction: Interaction {
    public GameObject cubeR3;
    public GameObject cubeNext;
    public GameObject cubeExtra;

    public override void OnAction()
    {
        cubeR3.GetComponent<Animator>().enabled = true;
        cubeNext.SetActive(true);
        cubeExtra.SetActive(true);
        
    }
}