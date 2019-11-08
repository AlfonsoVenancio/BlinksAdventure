using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingLives = 3;

    int currentLife;

    public Rigidbody2D rb;

    public float timeStopped;

    public float timeMoving;

    public float speed;

    Vector2 direction;

    private void Start()
    {
        currentLife = startingLives;
        Stop();
    }


    public void Stop()
    {
        rb.velocity = Vector2.zero;
        Invoke("Move",timeStopped);
    }


    public void Move()
    {
        direction = (GameManager.instance.player.transform.position - transform.position).normalized;
        rb.AddForce(direction*speed, ForceMode2D.Impulse);
        Invoke("Stop", timeMoving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.transform.CompareTag("Player"))
        {
            //GameManager.instance.player.Damage();
        }*/
        CancelInvoke();
        Stop();
    }


    public void Damage()
    {
        currentLife--;
        if (currentLife<=0)
        {
            //GameManager.instance.EnemyDead();
            Destroy(gameObject);
        }
    }
}
