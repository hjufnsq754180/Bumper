using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //Скрипт отвечающие за отталкивания объектов
    private Rigidbody rb;
    public float knockBackForce; //еденица силы отталкивания

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.collider.GetComponent<Rigidbody>(); //Берем в переменную rb Rigidbody объекта столкновения 

        if (rb != null) //Проверка на ноль
        {
            Vector3 dir = collision.transform.position - transform.position; //Задаем вектор направления
            rb.AddForce(dir.normalized * knockBackForce, ForceMode.Impulse); //Задаем силу отталкивания
        }
    }
}
