using UnityEngine;
using UnityEngine.SceneManagement;
using Discord;

public class DiscordController : MonoBehaviour
{
	private Scene scene;
	public static string curentDetails;
	public Discord.Discord discord;


	void Start()
	{
		discord = new Discord.Discord(1057647812789162075, (System.UInt64)Discord.CreateFlags.Default);
		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{
		discord.RunCallbacks();

		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = "In Game",
			Details = curentDetails,
			Assets =
			{
				 LargeImage = "avta", 
				 LargeText = "",
				 SmallImage = "None", 
				 SmallText = "", 
			},
		};
		activityManager.UpdateActivity(activity, (res) => { });
	}
}