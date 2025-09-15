using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManaging : MonoBehaviour
{
    #region Fields
    //make sure these are the same as the scene names, at least in the editor
    [SerializeField]
    string mainSceneName = "Main Game";
    [SerializeField]
    string mainMenuSceneName = "Main menu";
    [SerializeField]
    string uiSceneName = "UI";
    [SerializeField]
    string sortingGameSceneName = "Sorting game";
    #endregion
    #region Methods
    private IEnumerator Start()
    {
        //load all the scenes you want
        SceneManager.LoadScene(mainSceneName,LoadSceneMode.Additive);
        SceneManager.LoadScene(uiSceneName,LoadSceneMode.Additive);
        //unload this scene, as it is not needed
        yield return SceneManager.UnloadSceneAsync(gameObject.scene);
    }
    #endregion
}
