using UnityEngine;
using UnityEngine.UIElements;

public class EndScreenBehavior : MonoBehaviour
{
    private UIDocument endScreen;
    private Button nextButton;
    private Label scoreLabel;
    [SerializeField][Tooltip("What does it say before the score is mentioned. (Dansk)")] private string scoreTextDK;
    [SerializeField][Tooltip("What does it say before the score is mentioned. (English)")] private string scoreTextEN;

    void Awake()
    {
        endScreen = GetComponent<UIDocument>();
        nextButton = endScreen.rootVisualElement.Q("ToMainMenu_Btn") as Button;
        scoreLabel = endScreen.rootVisualElement.Q("FinalScore_Lbl") as Label;
        nextButton.RegisterCallback<ClickEvent>(OnNextButtonPressed);
        scoreLabel.text = $"{scoreTextEN} {GameBehavior_SO.PlayerScore}";
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
        GameObject.Find("ButtonSound").GetComponent<SoundEffectPlayer>().PlaySoundEffect();
        Debug.Log("Clicked To Main Menu");
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
