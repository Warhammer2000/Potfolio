using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 5f; // скорость врага
    [SerializeField]private Vector3 startPos;
    public float playerDistance = 50f; // расстояние, на котором враг замечает игрока

    private Transform player; // ссылка на игрока
    private bool playerInRange; // флаг, указывающий находится ли игрок в зоне видимости врага

    public float wanderRadius = 10f; // радиус области брождения
    public float wanderDistance = 5f; // расстояние, на которое враг будет смещаться от центра области
    public float wanderJitter = 1f; // сила случайной составляющей в направлении движения

    private Vector3 wanderTarget; // точка, к которой будет двигаться враг

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // находим игрока по тегу
        playerInRange = false; // изначально игрок находится вне зоны видимости врага


        wanderTarget = Random.insideUnitSphere * wanderRadius;
        wanderTarget += transform.position;
        wanderTarget.y = transform.position.y;
    }

    void Update()
    {
       
        // перемещаем врага в направлении игрока, если игрок находится в зоне видимости
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            // если игрок вне зоны видимости, то враг движется в случайном направлении
            transform.position += Random.insideUnitSphere * enemySpeed * Time.deltaTime;
        }

        // проверяем, находится ли игрок в зоне видимости врага
        if (Vector3.Distance(transform.position, player.position) < playerDistance)
        {
            playerInRange = true;
            // направляем взгляд врага на игрока
            //transform.LookAt(player);
        }
        else
        {
            playerInRange = false;
        }

        // смещаемся в направлении wanderTarget
        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, Time.deltaTime);

        // если приблизились к wanderTarget, то выбираем новую точку для брождения
        if (Vector3.Distance(transform.position, wanderTarget) < 0.1f)
        {
            wanderTarget = Random.insideUnitSphere * wanderRadius;
            wanderTarget += transform.position;
            wanderTarget.y = transform.position.y;
        }

        // добавляем случайную составляющую в направлении движения
        //wanderTarget += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * wanderJitter;
        //wanderTarget.Normalize();
        //wanderTarget *= wanderRadius;
        //wanderTarget += transform.position;
        //wanderTarget.y = transform.position.y;

        // поворачиваем в сторону движения
        //transform.LookAt(wanderTarget);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tep")
        {
            transform.position = startPos;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tep")
        {
            transform.position = startPos;
        }
    }


}
