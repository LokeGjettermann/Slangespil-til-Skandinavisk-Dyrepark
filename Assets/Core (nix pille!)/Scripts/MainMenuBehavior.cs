using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuBehavior : MonoBehaviour
{
    private UIDocument mainMenu;
    private Button startGameBtn;

    private void Awake()
    {
        mainMenu = GetComponent<UIDocument>();
        startGameBtn = mainMenu.rootVisualElement.Q("StartGameBtn") as Button;
        startGameBtn.RegisterCallback<ClickEvent>(OnStartClicked);
    }
    private void OnStartClicked(ClickEvent evt)
    {
        Debug.Log("Clicked Start");
        GetComponent<sceneManagingDuringRuntime>().StartCoroutine(GetComponent<sceneManagingDuringRuntime>().LoadScenes());
    }
}
