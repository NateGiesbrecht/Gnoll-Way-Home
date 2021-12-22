using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
   public int coins; 
   public TMP_Text coinUI; 

   //load panels 
   public ShopItemSO[] shopItemsSO;
   public GameObject[] shopPanelsGO;
   public ShopTemplate[] shopPanels;
   public Button[] myPurchaseBtns; 
   public Button[] myEquipBtns; 

   void Start()
   {
       PlayerPrefs.SetInt("Default", 1);  //Default ALWAYS unlocked 
       for ( int i = 0; i < shopItemsSO.Length; i++)
       {
           shopPanelsGO[i].SetActive(true);
       }
       coins = PlayerPrefs.GetInt("Coins", 0);
       coinUI.text = coins.ToString("00000");
       LoadPanels();
       CheckPurchasable();
       CheckEquipable();
   }

   void Update()
   {

   }

   public void AddCoins()
   {
       coins++;
       coinUI.text =  coins.ToString("00000");
       CheckPurchasable(); 
   }

   public void CheckPurchasable()
   {
       for(int i = 0; i < shopItemsSO.Length; i++)
       {
           int toCheck = PlayerPrefs.GetInt(shopItemsSO[i].title);
           if(coins >= shopItemsSO[i].baseCost && toCheck != 1)
           {
               myPurchaseBtns[i].interactable = true;
           }
           else
           {
               myPurchaseBtns[i].interactable = false;
           }
       }
   }

   public void CheckEquipable()
   {
       for(int i = 0; i < shopItemsSO.Length; i++)
       {
           int toCheck = PlayerPrefs.GetInt(shopItemsSO[i].title);
           if(toCheck == 1)
           {
               myEquipBtns[i].interactable = true;
           }
           else
           {
               myEquipBtns[i].interactable = false;
           }
       }
   }

   public void PurchaseItem(int bttnNo)
   {
       if(coins >= shopItemsSO[bttnNo].baseCost)
       {
           coins = coins - shopItemsSO[bttnNo].baseCost;
           
           //Set skin as bought 
           PlayerPrefs.SetInt(shopItemsSO[bttnNo].title, 1); 

           PlayerPrefs.SetInt("Coins", coins);
           coinUI.text = PlayerPrefs.GetInt("Coins", 0).ToString("00000"); 
           CheckPurchasable();
           CheckEquipable();

           //Unlock the item here 
       }
   }

   public void EquipItem(int bttnNo)
   {
       int toCheck = PlayerPrefs.GetInt(shopItemsSO[bttnNo].title);
       if(toCheck == 1)
       {
           Debug.Log("Equiped: " + shopItemsSO[bttnNo].title);
           PlayerPrefs.SetString("EquipedSkin", shopItemsSO[bttnNo].title);

           //Unlock the item here 
       }
   }

   public void LoadPanels()
   {
       for(int i = 0; i < shopItemsSO.Length; i++)
       {
           shopPanels[i].titleText.text = shopItemsSO[i].title;
           shopPanels[i].descriptionText.text = shopItemsSO[i].description;
           shopPanels[i].costText.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
           shopPanels[i].image.sprite = shopItemsSO[i].sprite;
       }
   }

   public void Back()
   {
       SceneManager.LoadScene("Menu");
   }
}
