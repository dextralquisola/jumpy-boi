using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text labelValue;
    private int levelCount;

    void Start()
    {
        levelCount = int.Parse(labelValue.text);

    }

    public void SetLevel(int newLevel)
    {
        levelCount = newLevel;
        UpdateUI();
    }

    private void UpdateUI()
    {
        labelValue.text = levelCount.ToString();
    }
    
}
