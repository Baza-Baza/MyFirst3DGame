using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public  int playerHealth;
    public  bool healthChanged;
    public  float batteryPower;
    public  bool batteryRefill;
    public  bool flashLightOn;
    public  bool nvLightOn;
    public  int apples;
    public  int battaries;
    public  bool axe;
    public  bool bat;
    public  bool crossbow;
    public  bool gun;
    public  bool knife;
    public  bool cabinKey;
    public  bool roomKey;
    public  bool houseKey;
    public  bool bulletsRefill;
    public  bool enoughBullet;
    public  int bulletClips;
    public  bool arrowRefill;
    public  bool haveAxe;
    public  bool haveKnife;
    public  bool haveBat;
    public  bool haveGun;
    public  bool haveCrossBow;
    public  int bullets;
    public  int bow;
    public  int maxEnemiesOnScreen;
    public  int enemiesOnScreen;
    public  float attackStamina;
    public  int maxEnemiesInGame;
    public  int currentEnemiesInGame;
    public  bool[] applesIcons = new bool[6];
    public bool[] batteriesIcons = new bool[4];
    public bool[] bullet_Icons = new bool[4];
    public List<int> applesInScene;
    public  bool applesButton;
    public int applesLeft;

    public GameData(SaveScript saveScript)
    {
        playerHealth = SaveScript.playerHealth;
        healthChanged = SaveScript.healthChanged;
        batteryPower = SaveScript.batteryPower;
        batteryRefill = SaveScript.batteryRefill;
        flashLightOn = SaveScript.flashLightOn;
        nvLightOn = SaveScript.nvLightOn;
        apples = SaveScript.apples;
        battaries = SaveScript.battaries;
        axe = SaveScript.axe;
        bat = SaveScript.bat;
        crossbow = SaveScript.crossbow;
        gun = SaveScript.gun;
        knife = SaveScript.knife;
        cabinKey = SaveScript.cabinKey;
        roomKey = SaveScript.roomKey;
        houseKey = SaveScript.houseKey;
        bulletsRefill = SaveScript.bulletsRefill;
        enoughBullet = SaveScript.enoughBullet;
        bulletClips = SaveScript.bulletClips;
        arrowRefill = SaveScript.arrowRefill;
        haveAxe = SaveScript.haveAxe;
        haveBat = SaveScript.haveBat;
        haveCrossBow = SaveScript.haveCrossBow;
        haveGun = SaveScript.haveGun;
        haveKnife = SaveScript.haveKnife;
        bullets = SaveScript.bullets;
        bow = SaveScript.bow;
        maxEnemiesInGame = SaveScript.maxEnemiesInGame;
        maxEnemiesOnScreen = SaveScript.maxEnemiesOnScreen;
        applesLeft = SaveScript.applesLeft;
        for (int i = 0; i < SaveScript.applesIcons.Count; i++)
        {
            applesIcons[i] = SaveScript.applesIcons[i].activeSelf;
        }
        for (int i = 0; i < SaveScript.batteriesIcons.Count; i++)
        {
            batteriesIcons[i] = SaveScript.batteriesIcons[i].activeSelf;
        }
        for (int i = 0; i < SaveScript.bullet_Icons.Count; i++)
        {
            bullet_Icons[i] = SaveScript.bullet_Icons[i].activeSelf;
        }
    }
}
