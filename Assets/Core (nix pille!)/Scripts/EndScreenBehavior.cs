using UnityEngine;
using UnityEngine.UIElements;

public class EndScreenBehavior : MonoBehaviour
{
    private UIDocument endScreen;
    private Button nextButton;
    private Label scoreLabel;
    private Label endScreenTitle;
    [SerializeField][Tooltip("Name of the end title label element")] private string endTextName = "EndScreenTitle_Lbl";
    [SerializeField][Tooltip("Name of the label element before the score")] private string scoreTextName = "FinalScore_Lbl";
    [SerializeField][Tooltip("Name of the button element")] private string buttonName = "ToMainMenu_Btn";
    [SerializeField] private string endTextDK;
    [SerializeField] private string endTextEN;
    [SerializeField][Tooltip("What does it say before the score is mentioned. (Dansk)")] private string scoreTextDK;
    [SerializeField][Tooltip("What does it say before the score is mentioned. (English)")] private string scoreTextEN;
    [SerializeField] private string buttonTextDK;
    [SerializeField] private string buttonTextEN;

    void Awake()
    {
        endScreen = GetComponent<UIDocument>();
        nextButton = endScreen.rootVisualElement.Q(buttonName) as Button;
        scoreLabel = endScreen.rootVisualElement.Q(scoreTextName) as Label;
        endScreenTitle = endScreen.rootVisualElement.Q(endTextName) as Label;
        nextButton.RegisterCallback<ClickEvent>(OnNextButtonPressed);
        
        if (ScriptableObject.FindFirstObjectByType<SetLanguage>() != null && ScriptableObject.FindFirstObjectByType<SetLanguage>().language == SetLanguage.Language.Dansk)
        {
            nextButton.text = buttonTextDK;
            scoreLabel.text = $"{scoreTextDK} {GameBehavior_SO.PlayerScore}";
            endScreenTitle.text = endTextDK;
        }
        else
        {
            nextButton.text = buttonTextEN;
            scoreLabel.text = $"{scoreTextEN} {GameBehavior_SO.PlayerScore}";
            endScreenTitle.text = endTextEN;
        }
    }


    private void OnNextButtonPressed(ClickEvent evnt)
    {
        Debug.Log("Clicked To Main Menu");
        Restart();
    }

    private void Restart()
    {
        GameBehavior_SO.ResetScore();
        sceneManagingDuringRuntime sceneChanger = GetComponent<sceneManagingDuringRuntime>();
        sceneChanger.StartCoroutine(sceneChanger.LoadScenes());

    }

}
