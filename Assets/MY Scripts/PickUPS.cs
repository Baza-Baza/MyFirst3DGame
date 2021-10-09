using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUPS : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float distance = 4.0f;
    [SerializeField] GameObject pickupMessage;
    [SerializeField] GameObject openMessage;
    [SerializeField] Text textMessageDoor;


    private float rayDistance;
    private bool canSeePickup = false;
    private bool canSeeDoor = false;
    private AudioSource player;
    // Start is called before the first frame update
    void Start()
    {
        pickupMessage.SetActive(false);
        openMessage.SetActive(false);
        rayDistance = distance;
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.apples < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.apples += 1;
                        player.Play();
                        SaveScript.enoughApple = true;
                    }
                }
            }
            else if (hit.transform.tag == "Battary")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.battaries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.battaries += 1;
                        player.Play();
                        SaveScript.enoughBattery = true;
                    }
                }
            }
            else if (hit.transform.tag == "Knife")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.knife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.knife = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Bat")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.bat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.bat = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Axe")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.axe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.axe = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "CrossBow")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.crossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.crossbow = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Gun")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.gun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.gun = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Bullet")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (SaveScript.bulletClips < 4)   
                     {
                            Destroy(hit.transform.gameObject);
                            SaveScript.bulletClips += 1;
                            player.Play();
                            SaveScript.enoughBullet = true;
                    }
                    
                }
            }
            else if (hit.transform.tag == "Arrow")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.arrowRefill == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.arrowRefill = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "CabinK")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.cabinKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.cabinKey = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "RoomK")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.roomKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.roomKey = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "HouseK")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.houseKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.houseKey = true;
                        player.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Door")
            {
                canSeeDoor = true;
                if (hit.transform.gameObject.GetComponent<DoorsScript>().locked == false)
                {
                    if (hit.transform.gameObject.GetComponent<DoorsScript>().isOpen == false)
                    {
                        textMessageDoor.text = "Press E to open";
                    }
                    else
                    {
                        textMessageDoor.text = "Press E to close";
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessage("OpenDoor");
                    }
                }
                else if (hit.transform.gameObject.GetComponent<DoorsScript>().locked == true)
                {
                    textMessageDoor.text = "You need the " + (hit.transform.gameObject.GetComponent<DoorsScript>().doorType) + " key";
                }
            }
            else
            {
                canSeePickup = false;
                canSeeDoor = false;
            }
            
           
        }
        if (canSeePickup == true)
        {
            pickupMessage.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeePickup == false)
        {
            pickupMessage.SetActive(false);
            rayDistance = distance;
        }
        if (canSeeDoor == true)
        {
            openMessage.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeeDoor  == false)
        {
            openMessage.SetActive(false);
            rayDistance = distance;
        }
    }
}
