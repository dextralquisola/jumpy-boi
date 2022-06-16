using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text labelValue;
    [SerializeField] Text lifeValue;
    [SerializeField] Text coinsValue;
    private int levelCount;
    public int lifeCount;
    private int coinsCount;


    void Start()
    {
        levelCount = int.Parse(labelValue.text);
        lifeCount = int.Parse(lifeValue.text);
        coinsCount = int.Parse(coinsValue.text);

        LoadValues();
    }

    private void LoadValues()
    {
        lifeCount = PlayerPrefs.GetInt("life");
        coinsCount = PlayerPrefs.GetInt("coins");

        if (lifeCount < 1) lifeCount = 3;
    }

    public void SetLevel(int newLevel)
    {
        levelCount = newLevel;
        UpdateUI();
    }

    public void AddLife()
    {
        lifeCount += 1;
        UpdateUI();
    }

    public void DeductLife()
    {
        lifeCount -= 1;
        UpdateUI();
    }

    public void AddCoins()
    {
        coinsCount += 1;

        if(coinsCount == 3)
        {
            lifeCount += 1;
            coinsCount = 0;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        PlayerPrefs.SetInt("life", lifeCount);
        PlayerPrefs.SetInt("coins", coinsCount);

        labelValue.text = levelCount.ToString();
        lifeValue.text = lifeCount.ToString();
        coinsValue.text = coinsCount.ToString();
    }
    
}
