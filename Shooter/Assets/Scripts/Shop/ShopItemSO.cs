using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)] //Creates a menu in unity right click 
public class ShopItemSO : ScriptableObject
{
    public string title; 
    public string description; 
    public int baseCost; 
    public Sprite sprite; 
    //public bool bought = false; 

}
