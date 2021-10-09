using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowUI : MonoBehaviour
{
    private Text BowText;
    // Start is called before the first frame update
    void Start()
    {
        BowText = GetComponent<Text>();
        UpdateUIBow();
    }

   public  void MinusBow()
    {
        if (SaveScript.bow > 0)
        {
            SaveScript.bow -= 1;
            UpdateUIBow();
        }
    }
    public void UpdateUIBow()
    {
        BowText.text = SaveScript.bow + "";
    }
}
