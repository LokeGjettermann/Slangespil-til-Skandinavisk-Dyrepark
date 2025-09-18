using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuBehavior : MonoBehaviour
{
    private UIDocument mainMenu;
    private Button startGameBtn;
    private Button muteGameBtn;
    private AudioManaging manager;
    [SerializeField]
    private Sprite muteBtnSprite;
    [SerializeField]
    private Sprite unmuteBtnSprite;
    private Button englishLanguageBtn;
    private Button danishLanguageBtn;
    private StyleBackground muteImg;
    private StyleBackground unmuteImg;

    private void Awake()
    {
        mainMenu = GetComponent<UIDocument>();
        startGameBtn = mainMenu.rootVisualElement.Q("StartGameBtn") as Button;
        startGameBtn.RegisterCallback<ClickEvent>(OnStartClicked);
        muteGameBtn = mainMenu.rootVisualElement.Q("MuteBtn") as Button;
        muteGameBtn.RegisterCallback<ClickEvent>(OnMuteClicked);
        try
        {
            manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManaging>();
        }
        catch { }
        englishLanguageBtn = mainMenu.rootVisualElement.Q("EnglishLanguageBtn") as Button;
        englishLanguageBtn.RegisterCallback<ClickEvent, VisualElement>(OnLanguageChange, englishLanguageBtn);
        danishLanguageBtn = mainMenu.rootVisualElement.Q("DanishLanguageBtn") as Button;
        danishLanguageBtn.RegisterCallback<ClickEvent, VisualElement>(OnLanguageChange, danishLanguageBtn);

        muteImg = new StyleBackground(muteBtnSprite);
        unmuteImg = new StyleBackground(unmuteBtnSprite);
        mainMenu.rootVisualElement.Q("ImageSetup").style.display = DisplayStyle.None;
    }
    private void OnStartClicked(ClickEvent evt)
    {
        Debug.Log("Clicked Start");
        GetComponent<sceneManagingDuringRuntime>().StartCoroutine(GetComponent<sceneManagingDuringRuntime>().LoadScenes());
    }
    private void OnMuteClicked(ClickEvent evt)
    {
        //if the scene is run on its own, there will be no soundmanager to find
        if (manager != null)
        {
            //mute or unmute sound
            manager.MuteSound();
            //change button icon depending on whether it's muted
            if (manager.Muted)
            {
                Debug.Log("Muted");
                muteGameBtn.style.backgroundImage = unmuteImg;
            }
            else
            {
                Debug.Log("Unmuted");
                muteGameBtn.style.backgroundImage = muteImg;
            }
        }

    }
    private void OnLanguageChange(ClickEvent evt, VisualElement element)
    {
        Debug.Log("Button called: " + element);
    }
}
