using UnityEngine;


[System.Serializable]
public class PlayerStatus 
{
    public string playerName;
    public int killNum, deathNum, flagNum;
    public Sprite profileSprite, playerSprite;

    [HideInInspector]
    public string title;
    [HideInInspector]
    public string dateTime;

}
