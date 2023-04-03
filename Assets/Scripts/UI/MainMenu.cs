using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void TransToDesert(){
        //转换场景
       SceneManager.LoadScene("DesertMap");
    }
    public void TransToSnow()
    {
        SceneManager.LoadScene("SnowMap");
    }
    public void TransToForest()
    {
        SceneManager.LoadScene("ForestMap");
    }
    public void TransToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Debug.Log("游戏结束");
        Application.Quit();
    }
}
