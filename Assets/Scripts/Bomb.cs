using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Animator anim;
    public float detonateTime;
    bool detonating = false;

    List<GameObject> damageObjects = new List<GameObject>();

    public void ActivateBomb()
    {
        damageObjects.Clear();
        anim.SetInteger("State",1);
        Invoke("Explote",detonateTime);
    }

    public void Explote()
    {
        detonating = true;
        anim.SetInteger("State", 2);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detonating && !damageObjects.Contains(collision.gameObject))
        {
            damageObjects.Add(collision.gameObject);
            //tell the other obget to take damage
            collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (detonating && !damageObjects.Contains(collision.gameObject))
        {
            damageObjects.Add(collision.gameObject);
            //tell the other obget to take damage
            collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (detonating && damageObjects.Contains(collision.gameObject))
        {
            damageObjects.Remove(collision.gameObject);
        }
    }

}
