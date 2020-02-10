using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperConsole : MonoBehaviour
{
    public Text Output;

    bool Active = false;

    Vector3 ActivePos;
    Vector3 InactivePos;

    //Setup callbacks
    void OnEnable()
    {
        Application.logMessageReceived += DeveloperLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= DeveloperLog;
    }

    void Start()
    {
        ActivePos = new Vector3(transform.localPosition.x, transform.localPosition.y - 180);
        InactivePos = new Vector3(transform.position.x, transform.localPosition.y);
    }

    void DeveloperLog(string LogString, string StackTrace, LogType Type)
    {
        if (Type != LogType.Log)
        {
            string StringMod;

            if (Type == LogType.Error)
            {
                StringMod = "<color=red>";
            }
            else if (Type == LogType.Warning)
            {
                StringMod = "<color=yellow>";
            }
            else if (Type == LogType.Exception)
            {
                StringMod = "<color=silver>";
            }
            else
            {
                StringMod = "<color=white>";
            }
            Output.text += "\n" + StringMod + LogString + "</color>";
        }
    }

    void Update()
    {
        if (Input.GetButtonUp("Console"))
        {
            if (Active)
            {
                Active = false;
                transform.localPosition = InactivePos;
            }
            else
            {
                Active = true;
                transform.localPosition = ActivePos;
            }
        }
    }
}
