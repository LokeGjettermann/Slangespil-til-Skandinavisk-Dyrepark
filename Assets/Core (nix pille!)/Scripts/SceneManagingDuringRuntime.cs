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
    public string mainSceneName = "Main Game";
    [Header("Menu")]
    [SerializeField]
    private string mainMenuSceneName = "Main menu";
    [SerializeField]
    private bool activateMainMenu = false;
    [SerializeField]
    private bool deactivateMainMenu = false;
    [Header("UI")]
    [SerializeField]
    private string uiSceneName = "UI";
    [SerializeField]
    private bool activateUI = false;
    [SerializeField]
    private bool deactivateUI = false;
    [Header("Sorting minigame")]
    [SerializeField]
    private string sortingGameSceneName = "Sorting minigame";
    [SerializeField]
    private bool activateSortingGame = false;
    [SerializeField]
    private bool deactivateSortingGame = false;
    #endregion
    #region Methods

    public IEnumerator LoadScenes()
    {
        Debug.Log("Loading scenes");
        //load all the scenes you want
        if (SceneManager.GetSceneByName(mainSceneName) == null || !SceneManager.GetSceneByName(mainSceneName).isLoaded)
        {
            SceneManager.LoadScene(mainSceneName, LoadSceneMode.Additive);
            while (!SceneManager.GetSceneByName(mainSceneName).isLoaded)
            {
                yield return new WaitForSeconds(0.1f);
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(mainSceneName));
        }
        if (activateMainMenu && !SceneManager.GetSceneByName(mainMenuSceneName).isLoaded)
        {
            SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
        }
        if (activateUI && !SceneManager.GetSceneByName(uiSceneName).isLoaded)
        {
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
        }
        if (activateSortingGame && !SceneManager.GetSceneByName(sortingGameSceneName).isLoaded)
        {
            SceneManager.LoadScene(sortingGameSceneName, LoadSceneMode.Additive);
        }
        if (deactivateMainMenu && SceneManager.GetSceneByName(mainMenuSceneName) != gameObject.scene && SceneManager.GetSceneByName(mainMenuSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(mainMenuSceneName));
        }
        if (deactivateUI && SceneManager.GetSceneByName(uiSceneName) != gameObject.scene && SceneManager.GetSceneByName(uiSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(uiSceneName));
        }
        if (deactivateSortingGame && SceneManager.GetSceneByName(sortingGameSceneName) != gameObject.scene && SceneManager.GetSceneByName(sortingGameSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sortingGameSceneName));
        }
        //unload this scene, as it is not needed anymore
        yield return SceneManager.UnloadSceneAsync(gameObject.scene);
    }
    #endregion
}
