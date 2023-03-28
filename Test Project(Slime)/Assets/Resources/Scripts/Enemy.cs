using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] public int damage;
    [SerializeField] private Image healthBar;
    private float perHealth;

    [SerializeField] float time = 2f;
    [SerializeField] private float Range;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject Effect;
    public static Enemy instance;
    void Start()
    {
        instance = this;    
        perHealth = 1.00f / health;
        Effect = transform.GetChild(1).gameObject;
        Effect.SetActive(false);
    }
    IEnumerator EffectDamage()
    {
        Effect.SetActive(true);
        yield return new WaitForSeconds(3f);
        Effect.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount -= perHealth * damage;
        if (health <= 0)
        {
            Controller.money += 10;
            Spawner.instance.Spawn();
            Destroy(gameObject);
        }

    }
    public void Damagable()
    {
        health -= damage * 2;
        healthBar.fillAmount -= perHealth * damage;
        StartCoroutine(EffectDamage());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.TakeDamage(damage);
        }
    }

  
    void Update()
    {
       // transform.position = Vector3.Lerp(transform.position, player.position, time * Time.deltaTime);
    }
}
