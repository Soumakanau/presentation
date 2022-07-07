using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverObserver : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    PlayerController PlayerScript;
    [SerializeField] GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = PlayerObj.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.hp == 0)
        {
            gameOver.SetActive(true);
        }
    }
}
