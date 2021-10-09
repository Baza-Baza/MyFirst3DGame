using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume myVolume;
    [SerializeField] PostProcessProfile standart;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] List<GameObject> flashLights;



    private bool nightVisionActive = false;
    private bool flashlightActive = false;

    private void Start()
    {
        nightVisionOverlay.SetActive(false);
        foreach (var x in flashLights)
        {
            x.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.batteryPower > 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (nightVisionActive == false)
                {
                    myVolume.profile = nightVision;
                    nightVisionActive = true;
                    nightVisionOverlay.SetActive(true);
                    SaveScript.nvLightOn = true;
                }
                else
                {
                    myVolume.profile = standart;
                    nightVisionActive = false;
                    nightVisionOverlay.SetActive(false);
                    SaveScript.nvLightOn = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flashlightActive == false)
                {
                    flashlightActive = true;
                    foreach (var x in flashLights)
                    {
                        x.SetActive(true);
                    }
                    SaveScript.flashLightOn = true;
                }
                else
                {
                    flashlightActive = false;
                    foreach (var x in flashLights)
                    {
                        x.SetActive(false);
                    }
                    SaveScript.flashLightOn = false;
                }
            }
        }
        if (SaveScript.batteryPower <= 0.0f)
        {
            myVolume.profile = standart;
            nightVisionActive = false;
            nightVisionOverlay.SetActive(false);
            SaveScript.nvLightOn = false;
            flashlightActive = false;
            foreach (var x in flashLights)
            {
                x.SetActive(false);
            }
            SaveScript.flashLightOn = false;
        }
    }
}
