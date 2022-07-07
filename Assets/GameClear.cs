using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public GameObject Player;
    public GameObject gameClear;


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == Player.name)
        {
            gameClear.GetComponent<Text>();
            gameClear.SetActive(true);
            Player.SetActive(false);
        }
    }
}

