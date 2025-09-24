using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private UIDocument endScreen;
    private Button nextButton;
    //private Label scoreLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endScreen = GetComponent<UIDocument>();
        nextButton = endScreen.rootVisualElement.Q("Next_Btn") as Button;
        //scoreLabel = endScreen.rootVisualElement.Q("FinalScore_Lbl") as Label;
        nextButton.RegisterCallback<ClickEvent>(OnNextButtonPressed);
        //scoreLabel.text = $"{scoreTextEN} {GameBehavior_SO.PlayerScore}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnNextButtonPressed(ClickEvent evnt)
    {
        sceneManagingDuringRuntime sceneChanger = /*GameObject.FindGameObjectWithTag("MenuItem").*/GetComponent<sceneManagingDuringRuntime>();
        sceneChanger.StartCoroutine(sceneChanger.LoadScenes());

    }
}
