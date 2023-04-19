using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScene : MonoBehaviour
{
    private Scene scene;

    public static CheckScene ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if(scene.name == "Offline" || scene.name == "Room")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(scene.name == "Offline")
        {
            DiscordController.curentDetails = "On the menu";
        }

        if(scene.name == "Room")
        {
            DiscordController.curentDetails = "In the lobby";
        }

        if(scene.name == "Game")
        {
            DiscordController.curentDetails = "Kills " + PlayerHealth.Kill.ToString();
        }
    }
}
