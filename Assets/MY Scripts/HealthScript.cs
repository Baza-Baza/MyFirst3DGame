using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = SaveScript.playerHealth + "%"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.healthChanged == true)
        {
            SaveScript.healthChanged = false;
            healthText.text = SaveScript.playerHealth + "%";

        }
    }
}
