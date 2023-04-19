using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject EscapePanel;
    public static bool IsPause;

    void Start()
    {
        EscapePanel.SetActive(IsPause = false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;
            EscapePanel.SetActive(IsPause);
        }
    }
}
