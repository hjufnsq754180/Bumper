using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    private Rigidbody rb;
    public TextMeshProUGUI namePlayer;
    public bool isAlive; // Проверка жив ли Player

    public string LastTakeEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
    }

    void Update()
    {
        Move();
        NickName();
    }

    void Move() // Метод передвижения
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }

    void NickName()
    {
        namePlayer.transform.position = transform.position + new Vector3(0, 1); // Отображение текса над Enemy
    }

    private void OnCollisionEnter(Collision collision) //Записываем имя Enemy при столкновении чтобы потом его отоброжать
    {
        if (collision.gameObject.tag == "Enemy") // Если объект столкновения имеет тэг Enemy, то мы записываем его имя в переменную типа стринг
        {
            LastTakeEnemy = collision.gameObject.name;
        }
    }
}
