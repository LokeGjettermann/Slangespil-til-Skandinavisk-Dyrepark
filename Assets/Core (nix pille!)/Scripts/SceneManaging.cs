using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManaging : MonoBehaviour
{
    #region Fields
    //make sure these are the same as the scene names, at least in the editor
    [Header("Main scene")]
    [SerializeField]
    [Tooltip("No switch for this one, Main Scene is what holds everything else, so should always be activated.")]
    string mainSceneName = "Main Game";
    [Header ("Menu")]
    [SerializeField]
    string mainMenuSceneName = "Main menu";
    [SerializeField]
    bool activateMainMenu = false;
    [Header("UI")]
    [SerializeField]
    string uiSceneName = "UI";
    [SerializeField]
    bool activateUI = true;
    [Header("Sorting minigame")]
    [SerializeField]
    string sortingGameSceneName = "Sorting minigame";
    [SerializeField]
    bool activateSortingGame = false;
    #endregion
    #region Methods
    private IEnumerator Start()
    {
        //load all the scenes you want
        SceneManager.LoadScene(mainSceneName, LoadSceneMode.Additive);
        if (activateMainMenu) 
        {
            SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
        }
        if (activateUI)
        {
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
        }
        if(activateSortingGame)
        {
            SceneManager.LoadScene(sortingGameSceneName, LoadSceneMode.Additive);
        }
        
        //unload this scene, as it is not needed anymore
        yield return SceneManager.UnloadSceneAsync(gameObject.scene);
    }
    #endregion
}
