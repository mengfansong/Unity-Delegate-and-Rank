using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public int currentIndex;    //showing current player info page

    [Header("Left UI Panel")]
    public GameObject[] slots;
    [Header("Right UI Panel")]
    public Text statusText;
    public Image playerImage;
    public Text playerNameText;
    public Text PlayerTitleText;

    private void Start()
    {
        UpdateLeftUI();
        UpdateRightUI();
        UpdateSlotAlpha();
    }

    private void UpdateLeftUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite=GameManager.instance.playerStatuses[i].profileSprite;
            slots[i].GetComponentInChildren<Text>().text = string.Format("{0}/{1}/{2}", GameManager.instance.playerStatuses[i].killNum, 
                                                                                        GameManager.instance.playerStatuses[i].deathNum,
                                                                                        GameManager.instance.playerStatuses[i].flagNum);

            slots[i].transform.GetChild(2).GetComponent<Text>().text = GameManager.instance.playerStatuses[i].dateTime;
        }
    }

    private void UpdateRightUI()
    {
        PlayerStatus playerStatus = GameManager.instance.playerStatuses[currentIndex];
        playerImage.sprite = playerStatus.playerSprite;
        playerNameText.text = playerStatus.playerName;
        statusText.text = string.Format("{0}/{1}/{2}", playerStatus.killNum, playerStatus.deathNum, playerStatus.flagNum);

        PlayerTitleText.text = playerStatus.title;
    }

    public void NextButton()
    {
        currentIndex++;
        if (currentIndex > slots.Length - 1)
        {
            currentIndex = 0;
        }

        UpdateRightUI();
        UpdateSlotAlpha();
    }

    public void BackButton()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = slots.Length - 1;
        }

        UpdateRightUI();
        UpdateSlotAlpha();
    }

    private void UpdateSlotAlpha()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i == currentIndex)
            {
                slots[i].GetComponent<CanvasGroup>().alpha = 1.0f;
                slots[i].transform.GetChild(0).GetComponentInChildren<ParticleSystem>().Play();
            }
            else
            {
                slots[i].GetComponent<CanvasGroup>().alpha = 0.5f;
                slots[i].transform.GetChild(0).GetComponentInChildren<ParticleSystem>().Stop();
            }
        }
    }

    public void UpdatePlayerTitle(string _topPlayerName,string _title,Func<PlayerStatus,string> _func)
    {
        for(int i = 0; i < GameManager.instance.playerStatuses.Length; i++)         //traverse all the players' statuses
        {
            if (GameManager.instance.playerStatuses[i].playerName == _topPlayerName)
            {
                GameManager.instance.playerStatuses[i].title += _title;
                GameManager.instance.playerStatuses[i].dateTime = _func(GameManager.instance.playerStatuses[i]);
            }
        }
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
}
