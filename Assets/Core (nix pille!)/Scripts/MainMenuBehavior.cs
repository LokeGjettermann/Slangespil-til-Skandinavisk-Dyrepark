using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuBehavior : MonoBehaviour
{
    #region Fields
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
    private Button quitGameBtn;
    private StyleBackground muteImg;
    private StyleBackground unmuteImg;
    [Header("Names of buttons")]
    [SerializeField]
    private string startGameButtonName = "StartGameBtn";
    [SerializeField]
    private string muteSoundButtonName = "MuteBtn";
    [SerializeField]
    private const string englishLanguageButtonName = "EnglishLanguageBtn";
    [SerializeField]
    private const string danishLanguageButtonName = "DanishLanguageBtn";
    [SerializeField]
    private string quitButtonName = "QuitBtn";
    [Space]
    [SerializeField]
    private string startBtnTextDanish;
    [SerializeField]
    private string startBtnTextEnglish;
    [SerializeField]
    private string quitBtnTextDanish;
    [SerializeField]
    private string quitBtnTextEnglish;

    private SetLanguage languageManager;
    private Scene mainScene;
    #endregion
    #region Methods

    private void Awake()
    {
        mainMenu = GetComponent<UIDocument>();
        startGameBtn = mainMenu.rootVisualElement.Q(startGameButtonName) as Button;
        startGameBtn.RegisterCallback<ClickEvent>(OnStartClicked);

        muteGameBtn = mainMenu.rootVisualElement.Q(muteSoundButtonName) as Button;
        muteGameBtn.RegisterCallback<ClickEvent>(OnMuteClicked);
        try
        {
            manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManaging>();
        }
        catch { }
        englishLanguageBtn = mainMenu.rootVisualElement.Q(englishLanguageButtonName) as Button;
        englishLanguageBtn.RegisterCallback<ClickEvent, VisualElement>(OnLanguageChange, englishLanguageBtn);
        danishLanguageBtn = mainMenu.rootVisualElement.Q(danishLanguageButtonName) as Button;
        danishLanguageBtn.RegisterCallback<ClickEvent, VisualElement>(OnLanguageChange, danishLanguageBtn);
        quitGameBtn = mainMenu.rootVisualElement.Q(quitButtonName) as Button;
        quitGameBtn.RegisterCallback<ClickEvent>(OnQuitGameClicked);

        muteImg = new StyleBackground(muteBtnSprite);
        unmuteImg = new StyleBackground(unmuteBtnSprite);
        languageManager = ScriptableObject.CreateInstance<SetLanguage>();

        if (languageManager.language == SetLanguage.Language.English)
        {
            startGameBtn.text = startBtnTextEnglish;
            quitGameBtn.text = quitBtnTextEnglish;
        }
        else
        {
            startGameBtn.text = startBtnTextDanish;
            quitGameBtn.text = quitBtnTextDanish;
        }
        try
        {
            mainScene = SceneManager.GetSceneByName(GetComponent<sceneManagingDuringRuntime>().mainSceneName);
            DontDestroyOnLoad(languageManager);
        }
        catch { }
    }
    private void OnStartClicked(ClickEvent evt)
    {
        Debug.Log("Clicked Start");
        GetComponent<sceneManagingDuringRuntime>().StartCoroutine(GetComponent<sceneManagingDuringRuntime>().LoadScenes());
    }
    private void OnMuteClicked(ClickEvent evt)
    {
        //if the scene is run on its own, there will be no soundmanager to find
        if (manager != null && mainScene != null)
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
        switch (element.name)
        {
            case englishLanguageButtonName:
                Debug.Log("Language changed to English");
                languageManager.ChangeLanguage(SetLanguage.Language.English);
                startGameBtn.text = startBtnTextEnglish;
                quitGameBtn.text = quitBtnTextEnglish;
                break;
            case danishLanguageButtonName:
                Debug.Log("Language changed to Danish");
                languageManager.ChangeLanguage(SetLanguage.Language.Dansk);
                startGameBtn.text = startBtnTextDanish;
                quitGameBtn.text = quitBtnTextDanish;
                break;
            default:
                Debug.Log("ERROR: Could not find language from \"" + element.name + "\"");
                break;
        }
    }
    private void OnQuitGameClicked(ClickEvent evt)
    {
        //not sure if we should just close the game here, don't want to shut down the entire app
    }
    #endregion
}
