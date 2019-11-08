using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float speed;
    Vector2 inputVector;
    Vector2 direction;
    Vector2 prevDirection;
    public Rigidbody2D rigidbody;

    public SpriteRenderer sprite;

    float angle = 0;

    int directionFacing;

    public GameObject bombPrefab;

    public float timeBetweenBombs;

    float nextTime2Bomb;

    Vector2 bombPos;

    public float invulnerabilityTime;

    float nextDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        nextDamageTime = Time.time;
        nextTime2Bomb = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        inputVector = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBomb();
        }*/



        /*
        if (inputVector != prevDirection)
        {
            prevDirection = inputVector;

            sprite.flipX = false;

            //set wich direction is facing
            //verify if you are getting any input
            if (inputVector.x != 0 || inputVector.y != 0)
            {
                //get the angle thath the Input forms in degrees
                angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
                if (angle < 0)
                {
                    angle = angle + 360;
                }

                //direction code
                //0: north
                //1: west
                //2: east
                //3: south
                if (angle >= 45f && angle < 135f)
                {
                    directionFacing = 0;
                    direction = Vector2.up;
                }
                else if (angle >= 135f && angle < 225f)
                {
                    direction = -Vector2.right;
                    directionFacing = 1;
                    sprite.flipX = true;
                }
                else if (angle >= 225f && angle < 315f)
                {

                    direction = -Vector2.up;
                    directionFacing = 3;
                }
                else
                {
                    direction = Vector2.right;
                    directionFacing = 2;
                }

            }
            else
            {
                direction = Vector2.zero;
            }

            anim.SetInteger("Direction", directionFacing);
            anim.SetFloat("speed", direction.magnitude);
        }
        //print(direction);
        rigidbody.MovePosition((Vector2)transform.position + direction * Time.deltaTime * speed);
        */

    }
    /*
    public void SpawnBomb(){
        if (nextTime2Bomb<Time.time && GameManager.instance.CurrentBombs>0)
        {
            //GameManager.instance.UseBomb();
            nextTime2Bomb = Time.time + timeBetweenBombs;
            
            Bomb aux = Instantiate(bombPrefab, transform.position, Quaternion.identity, GameManager.instance.transform).GetComponent<Bomb>();
            aux.ActivateBomb();

           
        }
    }*/

    /*
    public void Damage()
    {
        if (Time.time>nextDamageTime)
        {
            //nextDamageTime = Time.time + invulnerabilityTime;
            //GameManager.instance.Damage();
        }
    }*/
}
