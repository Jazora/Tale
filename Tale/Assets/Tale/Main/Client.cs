using UnityEngine;
using Steamworks;

public class Client : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);

        try
        {
            SteamClient.Init(480);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

        // Print out some basic information
        Debug.LogError("My Steam ID: " + SteamClient.SteamId);
        Debug.LogWarning("My Steam Username: " + SteamClient.Name);
    }

    void Update()
    {
        if (SteamClient.IsLoggedOn)
        {
            SteamClient.RunCallbacks();
        }
    }

    void OnDisable()
    {
        if (SteamClient.IsLoggedOn)
        {
            SteamClient.Shutdown();
        }
    }
}
