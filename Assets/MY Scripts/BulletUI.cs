using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    private Text bulletText;
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<Text>();
        UpdateUIBullet();
    }

   public  void MinusBullets()
    {
        if (SaveScript.bullets > 0)
        {
            SaveScript.bullets -= 1;
            UpdateUIBullet();
        }
    }
    public void UpdateUIBullet()
    {
        bulletText.text = SaveScript.bullets + "";
    }
}
