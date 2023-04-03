using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    GameObject player1;
    GameObject player2;
    private Transform InitPoint1;
    private Transform InitPoint2;

    void Start()
    {
        InitPoint1 = transform.Find("InitPoint1");
        InitPoint2 = transform.Find("InitPoint2");
        player1 = GameObject.Instantiate(players[PlayerPrefs.GetInt("SelectedCharacterIndex")], InitPoint1.position, InitPoint1.rotation) as GameObject;
        player1.SendMessage("SetNumber1");
        player1.SendMessage("SetFireKey2");
        player2 = GameObject.Instantiate(players[PlayerPrefs.GetInt("SelectedCharacterIndex_1")], InitPoint2.position, InitPoint2.rotation) as GameObject;
        player2.SendMessage("SetNumber2");
        player2.SendMessage("SetFireKey1");
    }



    void Update()
    {
        if(player1 != null)
        {
            InitPoint1.position = player1.transform.position;
        }
        if (player2 != null)
        {
            InitPoint2.position = player2.transform.position;
        }
        
    }
    /*public Transform GetEntrance_1()
    {
        foreach (var item in FindObjectsOfType<TransitionDestination>())
        {
            if (item.destinationTag == TransitionDestination.DestinationTag.ENTER1)
                return item.transform;
        }
        return null;
    }
    public Transform GetEntrance_2()
    {
        foreach (var item in FindObjectsOfType<TransitionDestination>())
        {
            if (item.destinationTag == TransitionDestination.DestinationTag.ENTER2)
                return item.transform;
        }
        return null;
    }*/
}
