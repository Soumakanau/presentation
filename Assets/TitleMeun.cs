using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMeun : MonoBehaviour
{
   // public void LoadCurrentScene()
    //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void OnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
