using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerFall : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    private int score = 0;
    public TextMeshProUGUI fallPlayer;
    public TextMeshProUGUI fallEnemy;
    public TextMeshProUGUI winText;
    public int countEnemy; // Отслеживание кол-во врагов на сцене

    private void Start()
    {
        scoreUI.text = score.ToString();
    }

    void Update()
    {
        Win();
    }

    void Win()
    {
        if (countEnemy <= 0)
        {
            winText.text = "YOU WIN!!!";
            FindObjectOfType<SceneCotroller>().unShowRestartButton.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //GameOver
        {
            fallPlayer.text = (FindObjectOfType<PlayerController>().LastTakeEnemy).ToString() + " dropped you!"; //Отображения того, кто тебя скинул
            if (FindObjectOfType<PlayerController>().LastTakeEnemy == "") // Если тебя никто не задевал и ты сам упал...
            {
                fallPlayer.text = "You dropped yourself..."; // Почему-то русский язык отображает некорректно =)
            }
            if (fallPlayer != null) // Если что-то написано в fallPlayer, то вызываем корутин, которые через 2сек убирает текст
            {
                StartCoroutine(FadeText());
            }
            FindObjectOfType<PlayerController>().isAlive = false; // Если падает игрок, то значение жизни меняется на false
        }
        if (other.gameObject.tag == "Enemy") //+Score
        {
            countEnemy -= 1;
            if (FindObjectOfType<Enemy>().LastTakePlayer == "Player") // Тут идет проверка, если упал Enemy и последним его коснулся Player, то очко засчитывает
            {
                fallEnemy.text = "You dropped " + other.gameObject.name;
                score += 1;
                scoreUI.text = score.ToString();
                if (fallEnemy != null)
                {
                    StartCoroutine(FadeText());
                }
            }
        }
    }

    private IEnumerator FadeText() //корутин
    {
        yield return new WaitForSeconds(2f); // вызов через 2сек
        fallPlayer.text = ""; // так мы убираем текс
        fallEnemy.text = ""; // так мы убираем текс
    }
}
