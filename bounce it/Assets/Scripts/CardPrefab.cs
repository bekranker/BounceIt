using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;



[CreateAssetMenu(fileName = "New Card", menuName = "blocks")]
public class CardPrefab : ScriptableObject
{
    public int StartCount;
    public GameObject ObstacleType;
    public Sprite ButtonImage;
}
