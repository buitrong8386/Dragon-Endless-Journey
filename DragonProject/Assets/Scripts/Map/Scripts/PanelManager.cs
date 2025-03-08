using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject panel;
    void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    public void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MapEnless");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Menu");
    }
}
