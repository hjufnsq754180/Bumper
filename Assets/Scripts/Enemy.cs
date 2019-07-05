using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float waitTime; // Время ожидания на споте
    public float startWaitTime;

    public Transform moveSpot; //Объект к которому идут Enemy
    public float minX; //Это все координаты плоскости на которой передвигаются игроки (Для круглой арена надо что-то через радиус) 
    public float maxX; //
    public float minZ; //
    public float maxZ; //

    public TextMeshProUGUI nameEnemy;
    public string LastTakePlayer;

    void Start()
    {
        waitTime = startWaitTime; 
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0.5f , Random.Range(minZ, maxZ)); //Задаем новые координаты споту движения
    }

    void Update()
    {
        EnemyMove();
        EnemyAIMoveSpot();
        NickName();
    }

    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime); //Передвижение Enemy с таргетом в виде moveSpot
        transform.LookAt(moveSpot.transform); // Поворот лицом к moveSpot при передвижении
    }

    void EnemyAIMoveSpot()
    {
        if (Vector3.Distance(transform.position, moveSpot.position) < 0.8f) // Условие на расстояние между Enemy и moveSpot объектом
        {
            if (waitTime <= 0) // Если нахождение Enemy на moveSpot закончилось, то создается рандомно новый спот, идет передвижение к нему и waitTime обнуляется на startTime
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void NickName()
    {
        nameEnemy.transform.position = transform.position + new Vector3(0, 1); // Отображение текса над Enemy
    }

    private void OnCollisionEnter(Collision collision) // Записываем имя объекта последнего столкновения
    {
        if (collision.gameObject.tag == "Player")
        {
            LastTakePlayer = collision.gameObject.name;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            LastTakePlayer = collision.gameObject.name;
        }
    }
}
