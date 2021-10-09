using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    private Animator anim;
    public bool isOpen = false;
    private AudioSource myPlayer;


    [SerializeField] AudioClip cabinClip;
    [SerializeField] AudioClip roomClip;
    [SerializeField] AudioClip houseClip;
    [SerializeField] bool cabin;
    [SerializeField] bool room;
    [SerializeField] bool house;

    public bool locked;
    public string doorType;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLock(cabin, SaveScript.cabinKey,"Cabin");
        CheckLock(room, SaveScript.roomKey, "Room");
        CheckLock(house, SaveScript.houseKey, "House");
    }
    public void OpenDoor()
    {
        if (isOpen == false)
        {
            anim.SetTrigger("Open");
            isOpen = true;
            ChangeSound(cabin, cabinClip);
            ChangeSound(room, roomClip); 
            ChangeSound(house, houseClip);
        }
        else if (isOpen == true)
        {
            anim.SetTrigger("Close");
            isOpen = false;
            ChangeSound(cabin, cabinClip);
            ChangeSound(room, roomClip);
            ChangeSound(house, houseClip);
        }
    }
    void ChangeSound(bool sound, AudioClip audioClip)
    {
        if (sound == true)
        {
                myPlayer.clip = audioClip;
                myPlayer.Play();
        }
    }
    void CheckLock(bool building, bool key, string stringDoorType)
    {
        if (building == true)
        {
            doorType = stringDoorType;
            if (key == true)
            {
                locked = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (locked == false)
            {
                if (isOpen == false)
                {
                    anim.SetTrigger("Open");
                    isOpen = true;
                }
            }
        }
    }
}
