using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    [SerializeField] ItemSO data;

    public int GetPoint()
    {
        return data.Point;
    }
}
