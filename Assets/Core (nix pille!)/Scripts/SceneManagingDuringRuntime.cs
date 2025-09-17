using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagingDuringRuntime : MonoBehaviour
{
    #region Fields
    //make sure these are the same as the scene names, at least in the editor
    [Header("Main scene")]
    [SerializeField]
    [Tooltip("No switch for this one, Main Scene is what holds everything else, so should always be activated.")]
    private string mainSceneName = "Main Game";
    [Header("Menu")]
    [SerializeField]
    private string mainMenuSceneName = "Main menu";
    [SerializeField]
    private bool activateMainMenu = false;
    [Header("UI")]
    [SerializeField]
    private string uiSceneName = "UI";
    [SerializeField]
    private bool activateUI = true;
    [Header("Sorting minigame")]
    [SerializeField]
    private string sortingGameSceneName = "Sorting minigame";
    [SerializeField]
    private bool activateSortingGame = false;
    #endregion
    #region Methods

    public IEnumerator LoadScenes()
    {
        Debug.Log("Loading scenes");
        //load all the scenes you want
        if (SceneManager.GetSceneByName(mainSceneName) == null || !SceneManager.GetSceneByName(mainSceneName).isLoaded)
        {
            SceneManager.LoadScene(mainSceneName, LoadSceneMode.Additive);
        }
        if (activateMainMenu)
        {
            SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
        }
        if (activateUI)
        {
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
        }
        if (activateSortingGame)
        {
            SceneManager.LoadScene(sortingGameSceneName, LoadSceneMode.Additive);
        }

        //unload this scene, as it is not needed anymore
        yield return SceneManager.UnloadSceneAsync(gameObject.scene);
    }
    #endregion
}
