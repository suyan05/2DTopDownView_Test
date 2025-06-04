using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Game/Item", menuName = "New/Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Data")]

    public int Point = 10;
}
