using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/PlayerEvent", fileName = "PlayerEvent")]
public class PlayerEvent : BaseEvent<PlayerData>
{
}

public class PlayerData
{
    public int Health = 100;
    public string Name = "Player 1";
}
