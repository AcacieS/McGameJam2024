using UnityEngine;

class GameExitButton: MonoBehaviour {
    public void OnClick() {
        Debug.Log("Quit");
        Application.Quit();
    }
}