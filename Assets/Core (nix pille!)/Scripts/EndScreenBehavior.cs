using UnityEngine;
using UnityEngine.UIElements;

public class EndScreenBehavior : MonoBehaviour
{
    private UIDocument endScreen;
    private Button nextButton;
    private Label scoreLabel;

    void Awake()
    {
        endScreen = GetComponent<UIDocument>();
        nextButton = endScreen.rootVisualElement.Q("ToMainMenu_Btn") as Button;
        scoreLabel = endScreen.rootVisualElement.Q("FinalScore_Lbl") as Label;
        nextButton.RegisterCallback<ClickEvent>(OnNextButtonPressed);
        scoreLabel.text += $": {GameBehavior_SO.PlayerScore}";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnNextButtonPressed(ClickEvent evnt)
    {
        Debug.Log("Clicked Next");
        Restart();
    }

    private void Restart()
    {
        GameBehavior_SO.ResetScore();
        // don't need to find the object, cus it's the object itself
        sceneManagingDuringRuntime sceneChanger = /*GameObject.FindGameObjectWithTag("MenuItem").*/GetComponent<sceneManagingDuringRuntime>();
        sceneChanger.StartCoroutine(sceneChanger.LoadScenes());

    }

}
