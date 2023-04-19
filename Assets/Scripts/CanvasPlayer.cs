using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasPlayer : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Weapon playerWeapon;
    [SerializeField] private GameObject EscapePanel;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider Sensitivityslider;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text killCount;
    [SerializeField] private TMP_Dropdown dropdownRes;
    [SerializeField] private TMP_Dropdown dropdownQuality;
    [SerializeField] private TMP_InputField SensitivitySliderField;
    [HideInInspector] public bool EscapeOpened;

    public static float SensitivityValue = CanvasMainMenu.SensitivityValue;
    public static CanvasPlayer ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void Start()
    {
        Sensitivityslider.value = CanvasMainMenu.SensitivityValue;
    }

    void Update()
    {
        sliderHealth.value = playerHealth.Health;
        ammoText.text = playerWeapon.ammo + "/30";
        healthText.text = playerHealth.Health.ToString();
        killCount.text = "Kills " + PlayerHealth.Kill.ToString();

        if(Input.GetKeyDown(KeyCode.Escape) && EscapeOpened == false)
        {
            EscapePanel.SetActive(true);
            EscapeOpened = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && EscapeOpened == true)
        {
            EscapePanel.SetActive(false);
            SettingsMenu.SetActive(false);
            EscapeOpened = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(SensitivityValue == 0 && SensitivitySliderField.text == "0")
        {
            SensitivitySliderField.text = "";
        }
    }

    public void Continue()
    {
        EscapePanel.SetActive(false);
        EscapeOpened = false;
        PauseGame.IsPause = !PauseGame.IsPause;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowSettings()
    {
        SettingsMenu.SetActive(true);
    }

    public void Exit()
    {
        PlayerNetwork.ins.StopGame();
        SceneManager.LoadScene("Offline");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EscapeOpened = false;
    }

    public void BackSettings()
    {
        SettingsMenu.SetActive(false);
    }

    public void SensitivityFieldChange()
    {
        float res;
        float.TryParse(SensitivitySliderField.text, out res);
        Sensitivityslider.value = res;
    }

    public void SliderValue()
    {
        SensitivityValue = Mathf.Round(Sensitivityslider.value * 10.00f) * 0.1f;
        SensitivitySliderField.text = SensitivityValue.ToString();
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

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
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


}
