using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int playerHealth = 85;
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
    public static bool savedGame = false;
    public static List<Transform> targets;
    public static Transform playerChar;
    public static GameObject chase;
    public static GameObject bloodScreen;
    public static Transform player;
    public static AudioSource stabPlayer;
    public static GameObject knifeBloodSpray;
    public static GameObject batBloodSpray;
    public static GameObject axeBloodSpray;
    public static Animator bloodAnim;
    public static int maxEnemiesOnScreen = 6;
    public static int enemiesOnScreen = 0;
    public static float attackStamina;
    public static int maxEnemiesInGame = 100;
    public static int currentEnemiesInGame = 0;
    public static int applesLeft =10 ;
    public static List<GameObject> applesIcons;
    public static List<GameObject> applesButtons;


    [SerializeField] List<Transform> _targets;
    [SerializeField] GameObject chaseMusic;
    [SerializeField] GameObject bloodUI;
    [SerializeField] AudioSource _stabPlayer;
    [SerializeField] GameObject _knifeBloodSpray;
    [SerializeField] GameObject _batBloodSpray;
    [SerializeField] GameObject _axeBloodSpray;
    [SerializeField] Animator _bloodAnim;
    [SerializeField] List<GameObject> _applesIcons;
    [SerializeField] List<GameObject> _applesButtons;
    private void Start()
    {
        player = gameObject.GetComponent<Transform>();
        bloodScreen = bloodUI;
        chase = chaseMusic;
        targets = new List<Transform>(_targets);
        applesIcons = new List<GameObject>(_applesIcons);
        applesButtons = new List<GameObject>(_applesButtons);
        stabPlayer = _stabPlayer;
        knifeBloodSpray = _knifeBloodSpray;
        batBloodSpray = _batBloodSpray;
        axeBloodSpray = _axeBloodSpray;
        bloodAnim = _bloodAnim;

        if (newGame == true)
        {
           
            playerHealth = 85;
                 healthChanged = true;
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
            applesLeft = 10;
        }
        if (savedGame == true)
        {
            playerHealth = PlayerPrefs.GetInt("PlayerHealth");
            healthChanged = true;
            batteryPower = PlayerPrefs.GetFloat("BattariesPower");
            apples = PlayerPrefs.GetInt("ApplesAmt");
            battaries = PlayerPrefs.GetInt("BattariesAmt");
            bulletClips = PlayerPrefs.GetInt("BulletsClips");
            bullets = PlayerPrefs.GetInt("BulletsAmt");
            bow = PlayerPrefs.GetInt("ArrowsAmt");
            maxEnemiesOnScreen = PlayerPrefs.GetInt("MaxEScreen");
            maxEnemiesInGame = PlayerPrefs.GetInt("MaxEGame");
            applesLeft = PlayerPrefs.GetInt("ApplesL");
            if (PlayerPrefs.GetInt("KnifeInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("BatInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("AxeInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("GunInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("CrossbowInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("CabinKeyInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("HouseKeyInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("RoomKeyInv") == 1)
            {
                knife = true;
            }
            if (PlayerPrefs.GetInt("ArrowR") == 1)
            {
                knife = true;
            }
            for (int i = 0; i < SaveScript.applesIcons.Count; i++)
            {
                if (PlayerPrefs.GetInt("ApplesM" + i) == 1)
                {
                    applesIcons[i].SetActive(true);
                    applesButtons[i].SetActive(true);
                }
                
            }
            GameData data = SaveSystem.LoadData();

            for (int i = 0; i < data.applesIcons.Length; i++)
            {
                if (data.applesIcons[i] == true)
                {
                    applesIcons[i].SetActive(true);
                    applesButtons[i].SetActive(true);
                }
            }
            savedGame = false;
        }
    }
    public void NewSaveData()
    {
        SaveSystem.SaveDataGAme(this);
    }


}
