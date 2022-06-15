using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int rotationSpeed;
    private HUDCanvas hudCanvas;

    void Start()
    {
        hudCanvas = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>();
        rotationSpeed = 150;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hudCanvas.AddCoins();

            Destroy(gameObject);
        }
    }
}
