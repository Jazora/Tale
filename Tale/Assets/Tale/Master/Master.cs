using UnityEngine;
using Steamworks;

public class Master : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(this);

        SteamServerInit serverInit = new SteamServerInit("gmod", "Garry Mode")
        {
            GamePort = 28015,
            Secure = true,
            QueryPort = 28016,
            DedicatedServer = false
        };

        try
        {
            SteamServer.Init(480, serverInit);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

        SteamServer.OnSteamServersConnected += () =>
        {
            Debug.Log("Connected");
        };
    }
}
