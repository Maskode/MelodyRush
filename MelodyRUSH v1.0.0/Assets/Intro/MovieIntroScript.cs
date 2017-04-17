using UnityEngine;

public class MovieIntroScript : MonoBehaviour {

    public string sceneToLoad = "Menu";
    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
