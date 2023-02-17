using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Yey I've got a health");

            gameManager.Items += 1;
            gameManager.PrintLootReport();
        }
    }
}
