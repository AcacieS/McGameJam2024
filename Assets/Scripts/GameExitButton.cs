using UnityEngine;

class GameExitButton: MonoBehaviour {
    public void OnClick() {
        GameObject.Find("ExitCanvas").GetComponent<AudioSource>().enabled = true;
    }
}