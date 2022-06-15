using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private Transform player;
    private HUDCanvas hudCanvas;


    private Vector3 previousPosition;
     
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        previousPosition = player.transform.position;
        hudCanvas = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>();


    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDed());
        }
    }
        
     
        IEnumerator PlayerDed()
        {
        //disable mesh

        player.GetComponent<MeshRenderer>().enabled = false;

        control playerControls = player.GetComponent<control>();
        playerControls.ArmLeft.enabled = false;
        playerControls.ArmRight.enabled = false;
        playerControls.body.enabled = false;
        playerControls.bodyy.enabled = false;
        playerControls.bodyyy.enabled = false;
        playerControls.Face.enabled = false;
        playerControls.Belt.enabled = false;
        playerControls.Pants.enabled = false;
        playerControls.Feet.enabled = false;
        playerControls.BeltSide.enabled = false;
        playerControls.RightHand.enabled = false;
        playerControls.LeftHand.enabled = false;
        playerControls.cubieFace.enabled = false;
        playerControls.SpawnParticles();

        playerControls.enabled = false;

        hudCanvas.DeductLife();

        yield return new WaitForSeconds(2f);

        if (hudCanvas.lifeCount < 1)
        {
            SceneManager.LoadScene("GameOver");
            PlayerPrefs.DeleteAll();
        }

        else
        {
            //respawn
            player.transform.position = previousPosition;
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            player.GetComponent<MeshRenderer>().enabled = true;
            playerControls.ArmLeft.enabled = true;
            playerControls.ArmRight.enabled = true;
            playerControls.body.enabled = true;
            playerControls.bodyy.enabled = true;
            playerControls.bodyyy.enabled = true;
            playerControls.Face.enabled = true;
            playerControls.Belt.enabled = true;
            playerControls.Pants.enabled = true;
            playerControls.Feet.enabled = true;
            playerControls.BeltSide.enabled = true;
            playerControls.RightHand.enabled = true;
            playerControls.LeftHand.enabled = true;
            playerControls.cubieFace.enabled = true;
            playerControls.enabled = true;
        }
        


    }
    }

