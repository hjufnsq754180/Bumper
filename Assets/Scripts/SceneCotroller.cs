using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCotroller : MonoBehaviour
{
    public GameObject unShowStartButton;
    public GameObject unShowChangeButton;
    public GameObject unShowRestartButton;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (FindObjectOfType<PlayerController>().isAlive != false)
        {
            unShowRestartButton.SetActive(false);
        }
        else
        {
            unShowRestartButton.SetActive(true);
        }
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        unShowStartButton.SetActive(false);
        unShowChangeButton.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSkin() // Меняем цвет на рандомный из RGB
    {
        player.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 255) / 100, Random.Range(0, 255) / 100, Random.Range(0, 255) / 100, 1);
    }
}
