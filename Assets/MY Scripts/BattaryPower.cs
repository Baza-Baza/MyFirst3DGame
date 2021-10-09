using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattaryPower : MonoBehaviour
{
    [SerializeField] Image batteryUI;
    [SerializeField] float drainTime = 180.0f;
    [SerializeField] float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.batteryRefill == true)
        {
            SaveScript.batteryRefill = false;
            batteryUI.fillAmount = 1.0f;
        }
        if (SaveScript.nvLightOn == true || SaveScript.flashLightOn == true)
        {
            batteryUI.fillAmount -= 1.0f / drainTime * Time.deltaTime;
            power = batteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }

        
    }
}
