using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int currentLevel;
    private HUDCanvas hudCanvas;


    // Start is called before the first frame update
    void Start()
    {
        hudCanvas = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>();
        hudCanvas.SetLevel(currentLevel);
    }

}
