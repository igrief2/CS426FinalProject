﻿using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, PlayerManager> players = new Dictionary<string, PlayerManager>();

    public static void RegisterPlayer(string netID, PlayerManager player)
    {
        string playerID = PLAYER_ID_PREFIX + netID;
        players.Add(playerID, player);
        player.transform.name = playerID;
    }

    public static void UnRegisterPlayer(string playerID)
    {
        players.Remove(playerID);
    }

    public static PlayerManager GetPlayer(string playerID)
    {
        return players[playerID];
    }
}
