using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 5f; // �������� �����
    [SerializeField]private Vector3 startPos;
    public float playerDistance = 50f; // ����������, �� ������� ���� �������� ������

    private Transform player; // ������ �� ������
    private bool playerInRange; // ����, ����������� ��������� �� ����� � ���� ��������� �����

    public float wanderRadius = 10f; // ������ ������� ���������
    public float wanderDistance = 5f; // ����������, �� ������� ���� ����� ��������� �� ������ �������
    public float wanderJitter = 1f; // ���� ��������� ������������ � ����������� ��������

    private Vector3 wanderTarget; // �����, � ������� ����� ��������� ����

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        playerInRange = false; // ���������� ����� ��������� ��� ���� ��������� �����


        wanderTarget = Random.insideUnitSphere * wanderRadius;
        wanderTarget += transform.position;
        wanderTarget.y = transform.position.y;
    }

    void Update()
    {
       
        // ���������� ����� � ����������� ������, ���� ����� ��������� � ���� ���������
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            // ���� ����� ��� ���� ���������, �� ���� �������� � ��������� �����������
            transform.position += Random.insideUnitSphere * enemySpeed * Time.deltaTime;
        }

        // ���������, ��������� �� ����� � ���� ��������� �����
        if (Vector3.Distance(transform.position, player.position) < playerDistance)
        {
            playerInRange = true;
            // ���������� ������ ����� �� ������
            //transform.LookAt(player);
        }
        else
        {
            playerInRange = false;
        }

        // ��������� � ����������� wanderTarget
        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, Time.deltaTime);

        // ���� ������������ � wanderTarget, �� �������� ����� ����� ��� ���������
        if (Vector3.Distance(transform.position, wanderTarget) < 0.1f)
        {
            wanderTarget = Random.insideUnitSphere * wanderRadius;
            wanderTarget += transform.position;
            wanderTarget.y = transform.position.y;
        }

        // ��������� ��������� ������������ � ����������� ��������
        //wanderTarget += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * wanderJitter;
        //wanderTarget.Normalize();
        //wanderTarget *= wanderRadius;
        //wanderTarget += transform.position;
        //wanderTarget.y = transform.position.y;

        // ������������ � ������� ��������
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
