using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private Button buttonHost, buttonClient;
    [SerializeField] private Slider Sensitivityslider;
    [SerializeField] private TMP_InputField NickanameField;
    [SerializeField] private TMP_InputField inputFieldAddress;
    [SerializeField] private TMP_InputField SensitivitySliderField;
    [SerializeField] private TMP_Dropdown dropdownRes;
    [SerializeField] private TMP_Dropdown dropdownQuality;

    public static float SensitivityValue;
    public static CanvasMainMenu ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void Start()
    {
        Sensitivityslider.value = 3f;

        if(NetworkManager.singleton.networkAddress != "localhost")
        {
            inputFieldAddress.text = NetworkManager.singleton.networkAddress;
        }

        inputFieldAddress.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        buttonHost.onClick.AddListener(ButtonHost);
        buttonClient.onClick.AddListener(ButtonClient);
    }

    private void Update()
    {
        if(SensitivityValue == 0 && SensitivitySliderField.text == "0")
        {
            SensitivitySliderField.text = "";
        }

        if(NickanameField.text == "")
        {
            buttonHost.interactable = false;
            buttonClient.interactable = false;
        }
        else
        {
            buttonHost.interactable = true;
            buttonClient.interactable = true;
        }
    }

    public void ResolutionDropdown()
    {
        if(dropdownRes.value == 0)
            Screen.SetResolution(1920, 1080, true);

        if(dropdownRes.value == 1)
            Screen.SetResolution(1680, 1050, true);

        if(dropdownRes.value == 2)
            Screen.SetResolution(1600, 1024, true);

        if(dropdownRes.value == 3)
            Screen.SetResolution(1600, 900, true);

        if(dropdownRes.value == 4)
            Screen.SetResolution(1440, 900, true);

        if(dropdownRes.value == 5)
            Screen.SetResolution(1366, 768, true);

        if(dropdownRes.value == 6)
            Screen.SetResolution(1360, 768, true);

        if(dropdownRes.value == 7)
            Screen.SetResolution(1280, 1024, true);

        if(dropdownRes.value == 8)
            Screen.SetResolution(1280, 960, true);

        if(dropdownRes.value == 9)
            Screen.SetResolution(1280, 800, true);

        if(dropdownRes.value == 10)
            Screen.SetResolution(1280, 768, true);

        if(dropdownRes.value == 11)
            Screen.SetResolution(1280, 720, true);

        if(dropdownRes.value == 12)
            Screen.SetResolution(1176, 664, true);

        if(dropdownRes.value == 13)
            Screen.SetResolution(1152, 864, true);

        if(dropdownRes.value == 14)
            Screen.SetResolution(1024, 768, true);

        if(dropdownRes.value == 15)
            Screen.SetResolution(800, 600, true);
    }

    public void Quality()
    {
        if(dropdownQuality.value == 0)
            QualitySettings.SetQualityLevel(0);

        if(dropdownQuality.value == 1)
            QualitySettings.SetQualityLevel(1);

        if(dropdownQuality.value == 2)
            QualitySettings.SetQualityLevel(2);

        if(dropdownQuality.value == 3)
            QualitySettings.SetQualityLevel(3);

        if(dropdownQuality.value == 4)
            QualitySettings.SetQualityLevel(4);

        if(dropdownQuality.value == 5)
            QualitySettings.SetQualityLevel(5);

        if(dropdownQuality.value == 6)
            QualitySettings.SetQualityLevel(6);
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SensitivityFieldChange()
    {
        float res;
        float.TryParse(SensitivitySliderField.text, out res);
        Sensitivityslider.value = res;
    }

    public void SettingsShow()
    {
        SettingsMenu.SetActive(true);
    }

    public void SettingsHide()
    {
        SettingsMenu.SetActive(false);
    }

    public void SliderValue()
    {
        
        SensitivityValue = Mathf.Round(Sensitivityslider.value * 10.00f) * 0.1f;
        SensitivitySliderField.text = SensitivityValue.ToString();
    }

    public void ValueChangeCheck()
    {
        NetworkManager.singleton.networkAddress = inputFieldAddress.text;
    }

    public void ButtonHost()
    {
        NetworkManager.singleton.StartHost();
    }

    public void ButtonServer()
    {
        NetworkManager.singleton.StartServer();
    }

    public void ButtonClient()
    {
        NetworkManager.singleton.StartClient();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}