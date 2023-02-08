using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject pause;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }
    public void PauseMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
