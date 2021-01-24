using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate int GetTopScoreDelegate(PlayerStatus playerStatus);


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerStatus[] playerStatuses;
    [HideInInspector]public string topKillName, topDeathName, topFlagName;

    private void Start()
    {
        topKillName = GetTopPlayer((player) => player.killNum);
        topDeathName = GetTopPlayer((player) => player.deathNum);
        topFlagName = GetTopPlayer((player) => player.flagNum);



        Debug.Log("kill :" + GetTopPlayer((playerStatus) => playerStatus.killNum));
        Debug.Log("Death :" + GetTopPlayer((playerStatus) => playerStatus.deathNum));
        Debug.Log("Flag :" + GetTopPlayer((playerStatus) => playerStatus.flagNum));

        UIManager.instance.UpdatePlayerTitle(topKillName, "<color=orange>超神，杀人如麻！</color>", Logger.Log);
        UIManager.instance.UpdatePlayerTitle(topDeathName, "<color=orange>超鬼，你在干嘛？</color>", Logger.Log);
        UIManager.instance.UpdatePlayerTitle(topFlagName, "<color=orange>好家伙，真会玩！</color>", Logger.Log);


    }

    private void OnEnable()
    {
       
    }




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        
    }

    public string GetTopPlayer(GetTopScoreDelegate _delegate)
    {
        int bestRecord = 0;
        string topName = "";
        foreach (PlayerStatus player in playerStatuses)
        {
            int tempNum = _delegate(player);
            if (tempNum > bestRecord)
            {
                bestRecord = tempNum;
                topName = player.playerName;
            }
        }
        return topName;
    }

  




}
