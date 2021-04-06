using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// THIS SCRIPT WILL BE HANDLING ALL FUNCTIONS USED BY THE MENU, END GAME SCENE, 
    /// OPTION AND PAUSE MENU.
    /// </summary>

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
    }

    //Menu and end game scene functions.
    public void PlayGame()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ToSettings()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void DifficultyScene()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void EasyScene()
    {
        SceneManager.LoadScene("DemoScene");
    }
    public void MediumScene()
    {
        SceneManager.LoadScene("Environment Test Scene");
    }
    public void HardScene()
    {
        //SceneManager.LoadScene("DifficultyScene");
    }
    //Option function(s).
    public AudioMixer audioMixer;
    public void SetVolume(float vol)
    {
        Debug.Log(vol);
        audioMixer.SetFloat("Volume", vol);
    }
}
