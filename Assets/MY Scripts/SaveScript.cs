using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int playerHealth = 100;
    public static bool healthChanged = false;
    public static bool enoughApple = false;
    public static float batteryPower = 1.0f;
    public static bool batteryRefill = false;
    public static bool enoughBattery = false;
    public static bool flashLightOn = false;
    public static bool nvLightOn = false;
    public static int apples = 0;
    public static int battaries = 0;
    public static bool axe = false;
    public static bool bat = false;
    public static bool crossbow = false;
    public static bool gun = false;
    public static bool knife = false;
    public static bool cabinKey = false;
    public static bool roomKey = false;
    public static bool houseKey = false;
    public static bool bulletsRefill = false;
    public static bool enoughBullet = false;
    public static int bulletClips = 0;
    public static bool arrowRefill = false;
    public static bool haveAxe = false;
    public static bool haveKnife = false;
    public static bool haveBat = false;
    public static bool haveGun = false;
    public static bool haveCrossBow = false;
    public static int bullets = 12;
    public static int bow = 6;
    public static bool newGame = false;

    private void Start()
    {
        if (newGame == true)
        {
                     playerHealth = 85;
                 healthChanged = false;
                 enoughApple = false;
                 batteryPower = 1.0f;
                 batteryRefill = false;
                 enoughBattery = false;
                flashLightOn = false;
                nvLightOn = false;
                apples = 0;
                 battaries = 0;
                 axe = false;
                 bat = false;
                 crossbow = false;
                 gun = false;
                knife = false;
                cabinKey = false;
                 roomKey = false;
                 houseKey = false;
                bulletsRefill = false;
                enoughBullet = false;
                 bulletClips = 0;
                 arrowRefill = false;
                 haveAxe = false;
                 haveKnife = false;
                 haveBat = false;
                 haveGun = false;
                 haveCrossBow = false;
                 bullets = 12;
                 bow = 6;
                 newGame = false;
}
    }

}
