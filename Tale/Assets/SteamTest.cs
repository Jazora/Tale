using UnityEngine;
using Steamworks;

public class SteamTest : MonoBehaviour
{
    void Start()
    {
        // Don't destroy this when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Create the steam client using the test AppID (or your own AppID eventually)
        try
        {
            SteamClient.Init(480);
        }
        catch (System.Exception e)
        {
            // Couldn't init for some reason (steam is closed etc)
        }

        // Print out some basic information
        Debug.Log("My Steam ID: " + SteamClient.SteamId);
        Debug.Log("My Steam Username: " + SteamClient.Name);
    }

    void OnDestroy()
    {
        if (SteamClient.IsLoggedOn)
        {
            Debug.Log("Test");
            SteamClient.Shutdown();
        }
    }
}