using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public static List<GameObject> batteriesIcons;
    public static List<GameObject> batteriesButtons;
    public static List<GameObject> weapon_Icons;
    public static List<GameObject> weapon_Buttons;
    public static List<GameObject> key_Buttons;
    public static List<GameObject> key_Icons;
    public static List<GameObject> bullet_Icons;
    public static List<GameObject> bullet_Buttons;
    public static List<GameObject> arrows;
    public static List<GameObject> applesInStart = new List<GameObject>()  ;


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
    [SerializeField] List<GameObject> _batteriesIcons;
    [SerializeField] List<GameObject> _batteriesButtons;
    [SerializeField] List<GameObject> _weapon_Icons;
    [SerializeField] List<GameObject> _weapon_Buttons;
    [SerializeField] List<GameObject> _key_Buttons;
    [SerializeField] List<GameObject> _key_Icons;
    [SerializeField] List<GameObject> _bullet_Icons;
    [SerializeField] List<GameObject> _bullet_Buttons;
    [SerializeField] List<GameObject> _arrows;

    private void Start()
    {
        player = gameObject.GetComponent<Transform>();
        bloodScreen = bloodUI;
        chase = chaseMusic;
        targets = new List<Transform>(_targets);
        applesIcons = new List<GameObject>(_applesIcons);
        applesButtons = new List<GameObject>(_applesButtons);
        batteriesButtons = new List<GameObject>(_batteriesButtons);
        batteriesIcons = new List<GameObject>(_batteriesIcons);
        weapon_Icons = new List<GameObject>(_weapon_Icons);
        weapon_Buttons = new List<GameObject>(_weapon_Buttons);
        key_Icons = new List<GameObject>(_key_Icons);
        key_Buttons = new List<GameObject>(_key_Buttons);
        bullet_Icons = new List<GameObject>(_bullet_Icons);
        bullet_Buttons = new List<GameObject>(_bullet_Buttons);
        arrows = new List<GameObject>(_arrows);


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
            GameData data = SaveSystem.LoadData();
            playerHealth = data.playerHealth;
            healthChanged = data.healthChanged;
            batteryPower = data.batteryPower;
            batteryRefill = data.batteryRefill;
            flashLightOn = data.flashLightOn;
            nvLightOn = data.nvLightOn;
            apples = data.apples;
            battaries = data.battaries;
            axe = data.axe;
            bat = data.bat;
            crossbow = data.crossbow;
            gun = data.gun;
            knife = data.knife;
            cabinKey = data.knife;
            roomKey = data.roomKey;
            houseKey = data.houseKey;
            bulletsRefill = data.bulletsRefill;
            enoughBullet = data.enoughBullet;
            bulletClips = data.bulletClips;
            arrowRefill = data.arrowRefill;
            haveAxe = data.haveAxe;
            haveKnife = data.haveKnife;
            haveBat = data.haveBat;
            haveGun = data.haveGun;
            haveCrossBow = data.haveCrossBow;
            bullets = data.bullets;
            bow = data.bow;
            applesLeft = data.applesLeft;
            for (int i = 0; i < data.destroyGameObjects.Count; i++)
            {
                applesInStart[i] = data.destroyGameObjects[i];
            }
            for (int i = 0; i < applesInStart.Count; i++)
            {
                Destroy(applesInStart[i]);
            }
            StartCoroutine(StartElements());

            savedGame = false;
        }
    }
    public void NewSaveData()
    {
        SaveSystem.SaveDataGAme(this);
    }
    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.2f);
        GameData data = SaveSystem.LoadData();
        
        for (int i = 0; i < applesIcons.Count; i++)
        {
            applesIcons[i].SetActive(data.applesIcons[i]);
            applesButtons[i].SetActive(data.applesIcons[i]);
        }
        for (int i = 0; i < batteriesIcons.Count; i++)
        {
            batteriesIcons[i].SetActive(data.batteriesIcons[i]);
            batteriesButtons[i].SetActive(data.batteriesIcons[i]);
        }
        for (int i = 0; i < bullet_Icons.Count; i++)
        {
            bullet_Icons[i].SetActive(data.bullet_Icons[i]);
            bullet_Buttons[i].SetActive(data.bullet_Icons[i]);
        }
    }


}
