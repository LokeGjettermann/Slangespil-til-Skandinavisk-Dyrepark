using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private UIDocument endScreen;
    private Button nextButton;
    private Label tutorialLabel;
    [SerializeField] [TextArea]
    private string tutorialDanish;
    [SerializeField]
    [TextArea]
    private string tutorialEnglish;
    [SerializeField]
    private string nextBtnTextDanish;
    [SerializeField]
    private string nextBtnTextEnglish;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endScreen = GetComponent<UIDocument>();
        nextButton = endScreen.rootVisualElement.Q("Next_Btn") as Button;
        nextButton.RegisterCallback<ClickEvent>(OnNextButtonPressed);
        tutorialLabel = endScreen.rootVisualElement.Q("Tutorial_Lbl") as Label;
        if (ScriptableObject.FindFirstObjectByType<SetLanguage>() != null && ScriptableObject.FindFirstObjectByType<SetLanguage>().language == SetLanguage.Language.Dansk)
        {
            tutorialLabel.text = tutorialDanish;
            nextButton.text = nextBtnTextDanish;
        }
        else
        {
            tutorialLabel.text = tutorialEnglish;
            nextButton.text = nextBtnTextEnglish;
        }
    }

    private void OnNextButtonPressed(ClickEvent evnt)
    {
        GameObject.Find("ButtonSound").GetComponent<SoundEffectPlayer>().PlaySoundEffect();
        sceneManagingDuringRuntime sceneChanger = /*GameObject.FindGameObjectWithTag("MenuItem").*/GetComponent<sceneManagingDuringRuntime>();
        sceneChanger.StartCoroutine(sceneChanger.LoadScenes());

    }
}
