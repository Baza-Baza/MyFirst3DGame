using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public int dataExists = 10;
    [SerializeField] private GameObject loadButton;
    private Inventory inventory;

    private void Start()
    {
        GameData data = SaveSystem.LoadData();
        if (loadButton != null)
        {
            dataExists = data.playerHealth;
            if (dataExists > 0)
            {
                loadButton.SetActive(true);
            }
        }
        
    }
    public void LoadGameData()
    {
        SaveScript.savedGame = true;
    }
   
    
    
}
