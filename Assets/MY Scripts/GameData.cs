using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    /*public  int playerHealth;
    public  bool healthChanged;
    public  bool enoughApple;
    public  float batteryPower;
    public  bool batteryRefill;
    public  bool enoughBattery;
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
    public  bool newGame;
    public  bool savedGame;
    public  List<Transform> targets;
    public  Transform playerChar;
    public  GameObject chase;
    public  GameObject bloodScreen;
    public  Transform player;
    public  AudioSource stabPlayer;
    public  GameObject knifeBloodSpray;
    public  GameObject batBloodSpray;
    public  GameObject axeBloodSpray;
    public  Animator bloodAnim;
    public  int maxEnemiesOnScreen;
    public  int enemiesOnScreen;
    public  float attackStamina;
    public  int maxEnemiesInGame;
    public  int currentEnemiesInGame;
    public  int applesLeft;*/
    public  bool[] applesIcons;
    public  List<bool> applesButtons;

    public GameData(SaveScript saveScript)
    {
        applesIcons = new bool[6];
        for (int i = 0; i < SaveScript.applesIcons.Count; i++)
        {
            if (SaveScript.applesIcons[i].activeSelf == true)
            {
                applesIcons[i] = true; 
            }
        }
    }
}
