using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Logger 
{
    public static string Log(PlayerStatus player)
    {
        DateTime currentTime = DateTime.UtcNow;
        Debug.Log(currentTime.ToString());
        Debug.Log(string.Format("{0} has reached {1} on {2}",player.playerName,player.title,player.dateTime));
        return currentTime.ToString();
    }
}
