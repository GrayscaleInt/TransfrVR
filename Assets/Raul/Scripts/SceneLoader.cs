using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Select scene index that wants to be loaded on button press. Main Menu = 0, Drill Test = 1. To load new scene, add it to Build Settings and set Index here")] int sceneIndexToLoad = 1;


    /*

    private void Update()
    {
        OnKeyPress();

        Debug.Log(SceneManager.GetActiveScene());
    }

    void OnKeyPress()
    {
        if (Input.anyKeyDown)
        {
            switch (Input.inputString)
            {
                case "e":
                    LoadMainMenu();
                    break;

                case "q":
                    SceneToLoad();
                    break;
            }
        }
    }

    */

    public void SceneToLoad()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; //In case the scene in the build index is the last number, then return to main menu.
            if (SceneManager.GetActiveScene().name == "ShaderTests") { return; }
        }
        SceneManager.LoadScene(currentSceneIndex + sceneIndexToLoad);
        SceneManager.UnloadSceneAsync("ShaderTests");
    }

    public void LoadMainMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().name == "ShaderTests") { return; } //if main menu is already loaded, do not reload.
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }

}
