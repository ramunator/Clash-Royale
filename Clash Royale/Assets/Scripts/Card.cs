using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gameplay/Card")]
public class Card : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public int elixrCost;
    public Transform troopPf;
}
