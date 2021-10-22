using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public int dataExists = 10;
    [SerializeField] private GameObject loadButton;
    private Inventory inventory;

    private void Start()
    {
        if (loadButton != null)
        {
            dataExists = PlayerPrefs.GetInt("PlayerHealth", 0);
            if (dataExists > 0)
            {
                loadButton.SetActive(true);
            }
        }
        
    }
    public void LoadGameData()
    {
        SaveScript.savedGame = true;
    }
   
    public void SaveGame()
    {
        PlayerPrefs.SetInt("PlayerHealth", SaveScript.playerHealth);
        PlayerPrefs.SetFloat("BattariesPower", SaveScript.batteryPower);
        PlayerPrefs.SetInt("ApplesAmt", SaveScript.apples);
        PlayerPrefs.SetInt("BattariesAmt", SaveScript.battaries);
        PlayerPrefs.SetInt("BulletsClips", SaveScript.bulletClips);
        PlayerPrefs.SetInt("BulletsAmt", SaveScript.bullets);
        PlayerPrefs.SetInt("ArrowsAmt", SaveScript.bow);
        PlayerPrefs.SetInt("MaxEScreen", SaveScript.maxEnemiesOnScreen);
        PlayerPrefs.SetInt("MaxEGame", SaveScript.maxEnemiesInGame);
        PlayerPrefs.SetInt("ApplesL", SaveScript.applesLeft);
        if (SaveScript.knife == true)
        {
            PlayerPrefs.SetInt("KnifeInv", 1);
        }
        if (SaveScript.bat == true)
        {
            PlayerPrefs.SetInt("BatInv", 1);
        }
        if (SaveScript.axe == true)
        {
            PlayerPrefs.SetInt("AxeInv", 1);
        }
        if (SaveScript.gun == true)
        {
            PlayerPrefs.SetInt("GunInv", 1);
        }
        if (SaveScript.crossbow == true)
        {
            PlayerPrefs.SetInt("CrossbowInv", 1);
        }
        if (SaveScript.cabinKey == true)
        {
            PlayerPrefs.SetInt("CabinKeyInv", 1);
        }
        if (SaveScript.houseKey == true)
        {
            PlayerPrefs.SetInt("HouseKeyInv", 1);
        }
        if (SaveScript.roomKey == true)
        {
            PlayerPrefs.SetInt("RoomKeyInv", 1);
        }
        if (SaveScript.arrowRefill == true)
        {
            PlayerPrefs.SetInt("ArrowR", 1);
        }

        PlayerPrefs.Save();

    }
    
}
