using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] List<GameObject> ApplesIcons;
    [SerializeField] List<GameObject> ApplesButtons;
    [SerializeField] List<GameObject> BatteryIcons;
    [SerializeField] List<GameObject> BatteryButtons;
    [SerializeField] List<GameObject> Weapon_Icons;
    [SerializeField] List<GameObject> Weapon_Buttons;
    [SerializeField] List<GameObject> Key_Buttons;
    [SerializeField] List<GameObject> Key_Icons;
    [SerializeField] List<GameObject> Bullet_Icons;
    [SerializeField] List<GameObject> Bullet_Buttons;
    [SerializeField] List<GameObject> Arrows;
    [SerializeField] AudioClip appleBite;
    [SerializeField] AudioClip batteryChange;
    [SerializeField] AudioClip weaponChange;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip arrowShot;
    [SerializeField] GameObject playerArms;
    [SerializeField] List<GameObject> MeleeWeapon;
    [SerializeField] List<GameObject> ShootingWeapon;
    [SerializeField] Animator anim;
    [SerializeField] GameObject gunUI;
    [SerializeField] GameObject bulletAmt;
    [SerializeField] GameObject crossbowUI;
    [SerializeField] GameObject bowAmt;




    private bool isInventory = false;
    private AudioSource player;
    public UnityEvent bulletEvent;
    public UnityEvent bowEvent;

    // Start is called before the first frame update
    private void Start()
    {
        playerArms.SetActive(false);
        gunUI.SetActive(false);
        bulletAmt.SetActive(false);
        player = GetComponent<AudioSource>();
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        for (int i = 0; i < ApplesButtons.Count; i++)
        {
            ApplesButtons[i].SetActive(false);
        }
        for (int i = 0; i < ApplesIcons.Count; i++)
        {
            ApplesIcons[i].SetActive(false);
        }
        for (int i = 0; i < BatteryIcons.Count; i++)
        {
            BatteryIcons[i].SetActive(false);
        }
        for (int i = 0; i < BatteryButtons.Count; i++)
        {
            BatteryButtons[i].SetActive(false);
        }
        for (int i = 0; i < Weapon_Buttons.Count; i++)
        {
            Weapon_Buttons[i].SetActive(false);
        }
        for (int i = 0; i < Weapon_Icons.Count; i++)
        {
            Weapon_Icons[i].SetActive(false);
        }
        for (int i = 0; i < Key_Buttons.Count; i++)
        {
            Key_Buttons[i].SetActive(false);
        }
        for (int i = 0; i < Key_Icons.Count; i++)
        {
            Key_Icons[i].SetActive(false);
        }
        for (int i = 0; i < Bullet_Icons.Count; i++)
        {
            Bullet_Icons[i].SetActive(false);
        }
        for (int i = 0; i < Bullet_Buttons.Count; i++)
        {
            Bullet_Buttons[i].SetActive(false);
        }
        for (int i = 0; i < Arrows.Count; i++)
        {
            Arrows[i].SetActive(false);
        }
        for (int i = 0; i < MeleeWeapon.Count; i++)
        {
            MeleeWeapon[i].SetActive(false);
        }
        for (int i = 0; i < ShootingWeapon.Count; i++)
        {
            ShootingWeapon[i].SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
         {
            if (isInventory == false)
            {
                inventoryPanel.gameObject.SetActive(true);
                isInventory = true;
                Time.timeScale = 0f;
                Cursor.visible = true;

            }
            else
            {
                inventoryPanel.gameObject.SetActive(false);
                isInventory = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
            
        }
            CheckInventory();
            CheckWeapons();
        CheckBulletANDAroows();
        CheckKeys();
    }
   
    void CheckInventory()
    {
        if (SaveScript.enoughApple == true)
        {
            SaveScript.enoughApple = false;
                for (int i = 0; i < 6; i++)
                {
                    if (ApplesButtons[i].activeSelf == false)
                    {
                        ApplesButtons[i].SetActive(true);
                        ApplesIcons[i].SetActive(true);
                        Debug.Log(ApplesIcons[i]);
                        break;
                    }

                }
        }
        if (SaveScript.enoughBattery == true)
        {
            SaveScript.enoughBattery = false;
                for (int i = 0; i < 4; i++)
                {
                    if (BatteryButtons[i].activeSelf == false)
                    {
                        BatteryButtons[i].SetActive(true);
                        BatteryIcons[i].SetActive(true);
                        Debug.Log(BatteryButtons[i]);
                        break;
                    }

                }
        }
    }
    void CheckWeapons()
    {
        if (SaveScript.axe == true)
        {
            Weapon_Buttons[0].SetActive(true);
            Weapon_Icons[0].SetActive(true);
        }
        if (SaveScript.bat == true)
        {
            Weapon_Buttons[1].SetActive(true);
            Weapon_Icons[1].SetActive(true);
        }
        if (SaveScript.crossbow == true)
        {
            Weapon_Buttons[2].SetActive(true);
            Weapon_Icons[2].SetActive(true);
        }
        if (SaveScript.gun == true)
        {
            Weapon_Buttons[3].SetActive(true);
            Weapon_Icons[3].SetActive(true);
        }
        if (SaveScript.knife == true)
        {
            Weapon_Buttons[4].SetActive(true);
            Weapon_Icons[4].SetActive(true);
        }
    }
   void CheckBulletANDAroows()
    {
        if (SaveScript.arrowRefill == true)
        {   
                Arrows[0].SetActive(true);
                Arrows[1].SetActive(true);
        }
        if (SaveScript.enoughBullet == true)
            {
                SaveScript.enoughBullet = false;
                for (int i = 0; i < 4; i++)
                {
                    if (Bullet_Buttons[i].activeSelf == false)
                    {
                        Bullet_Buttons[i].SetActive(true);
                        Bullet_Icons[i].SetActive(true);
                        Debug.Log(Bullet_Icons[i]);
                        break;
                    }

                }
            }
    }
    void CheckKeys()
    {
        if (SaveScript.cabinKey == true)
        {
            Key_Buttons[0].SetActive(true);
            Key_Icons[0].SetActive(true);
        }
        if (SaveScript.houseKey == true)
        {
            Key_Buttons[1].SetActive(true);
            Key_Icons[1].SetActive(true);
        }
        if (SaveScript.roomKey == true)
        {
            Key_Buttons[2].SetActive(true);
            Key_Icons[2].SetActive(true);
        }

    }
    public void  HeathUpdate(Button button)
    {
        if (SaveScript.playerHealth < 100)
        {
            SaveScript.playerHealth += 10;
            SaveScript.healthChanged = true;
            switch (button.tag)
            {
                case "1A":
                    ApplesButtons[0].SetActive(false);
                    ApplesIcons[0].SetActive(false);
                    break;
                case "2A":
                    ApplesButtons[1].SetActive(false);
                    ApplesIcons[1].SetActive(false);
                    break;
                case "3A":
                    ApplesButtons[2].SetActive(false);
                    ApplesIcons[2].SetActive(false);
                    break;
                case "4A":
                    ApplesButtons[3].SetActive(false);
                    ApplesIcons[3].SetActive(false);
                    break;
                case "5A":
                    ApplesButtons[4].SetActive(false);
                    ApplesIcons[4].SetActive(false);
                    break;
                case "6A":
                    ApplesButtons[5].SetActive(false);
                    ApplesIcons[5].SetActive(false);
                    break;
            }
            Debug.Log(button.tag);
            SaveScript.apples -= 1;
            ChangeAiudoClip(appleBite);
            if (SaveScript.playerHealth > 100)
            {
                SaveScript.playerHealth = 100;
            }
        }
    }
    public void BattaryUpdate(Button button)
    {
        if (SaveScript.batteryPower < 1.0f)
        {
            SaveScript.batteryRefill = true;
            switch (button.tag)
            {
                case "1B":
                    BatteryButtons[0].SetActive(false);
                    BatteryIcons[0].SetActive(false);
                    break;
                case "2B":
                    BatteryButtons[1].SetActive(false);
                    BatteryIcons[1].SetActive(false);
                    break;
                case "3B":
                    BatteryButtons[2].SetActive(false);
                    BatteryIcons[2].SetActive(false);
                    break;
                case "4B":
                    BatteryButtons[3].SetActive(false);
                    BatteryIcons[3].SetActive(false);
                    break;
            }

            ChangeAiudoClip(batteryChange);
            SaveScript.battaries -= 1;
        }
    }
    public void ArrowsUpdate()
    {
        SaveScript.arrowRefill = false;
        Arrows[0].SetActive(false);
        Arrows[1].SetActive(false);
        SaveScript.bow = 6;
        bowEvent.Invoke();
    }
    public void BulletUpdate(Button button)
    {
        if (SaveScript.bullets < 12)
        {
            switch (button.tag)
            {
                case "Bul1":
                    Bullet_Buttons[0].SetActive(false);
                    Bullet_Icons[0].SetActive(false);
                    break;
                case "Bul2":
                    Bullet_Buttons[1].SetActive(false);
                    Bullet_Icons[1].SetActive(false);
                    break;
                case "Bul3":
                    Bullet_Buttons[2].SetActive(false);
                    Bullet_Icons[2].SetActive(false);
                    break;
                case "Bul4":
                    Bullet_Buttons[3].SetActive(false);
                    Bullet_Icons[3].SetActive(false);
                    break;
            }
            SaveScript.bulletClips -= 1;
            SaveScript.bullets = 12;
            bulletEvent.Invoke();
            Debug.Log(SaveScript.bulletClips);
        }
    }

    public void AssignMeleeWeapon(Button button)
    {
        playerArms.SetActive(true);
        anim.SetBool("Melee", true);
        FalseWeapon();
        switch (button.tag)
        {
            case "Knife":               
                AssignWeaponSwitch(MeleeWeapon[0], weaponChange);
                SaveScript.haveKnife = true;
                break;
            case "Bat":            
                AssignWeaponSwitch(MeleeWeapon[1], weaponChange);
                SaveScript.haveBat = true;
                break;
            case "Axe":               
                AssignWeaponSwitch(MeleeWeapon[2], weaponChange);
                SaveScript.haveAxe = true;
                break;
        }
    }
    public void AssignShootingWeapon(Button button)

    {
        playerArms.SetActive(true);
        anim.SetBool("Melee", false);
        FalseWeapon();
        switch (button.tag)
        {
            case "CrossBow":
                ShootingWeapon[0].SetActive(true);
                ChangeAiudoClip(arrowShot);
                SaveScript.haveCrossBow = true;
                crossbowUI.SetActive(true);
                bowAmt.SetActive(true);
                break;
            case "Gun":
                ShootingWeapon[1].SetActive(true);
                ChangeAiudoClip(gunShot);
                SaveScript.haveGun = true;
                gunUI.SetActive(true);
                bulletAmt.SetActive(true);
                break;

        }
    }
    private void AssignWeaponSwitch(GameObject weapon, AudioClip changeWeapon)
    {
        weapon.SetActive(true);
        ChangeAiudoClip(changeWeapon);
    }

    private void ChangeAiudoClip(AudioClip audioClip)
    {
        player.clip = audioClip;
        player.Play();
    }
    private void FalseWeapon()
    {
        SaveScript.haveAxe = false;
        SaveScript.haveBat = false;
        SaveScript.haveKnife = false;
        SaveScript.haveGun = false;
        SaveScript.haveCrossBow = false;
        gunUI.SetActive(false);
        bulletAmt.SetActive(false);
        crossbowUI.SetActive(false);
        bowAmt.SetActive(false);
    }
    public void WeaponOFF()
    {
        for (int i = 0; i < MeleeWeapon.Count; i++)
        {
            MeleeWeapon[i].SetActive(false);
        }
        for (int i = 0; i < ShootingWeapon.Count; i++)
        {
            ShootingWeapon[i].SetActive(false);
        }

    }
    
}