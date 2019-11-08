using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SpawnObject
{
    health, bomb
}


public class RandomObject : MonoBehaviour
{
    public SpriteRenderer healthSprite;
    public SpriteRenderer bombSprite;

    public float time2Spawn;

    public List<Transform> spawnPlaces;

    SpawnObject object2Spawn;

    bool active = false;

    private void Start()
    {
        healthSprite.gameObject.SetActive(false);
        bombSprite.gameObject.SetActive(false);
        Invoke("SpawnObj",time2Spawn);
    }


    public void SpawnObj()
    {
        if (!active)
        {
            object2Spawn = (Random.Range(0f, 1f) > 0.5) ? SpawnObject.bomb : SpawnObject.health;
            if (object2Spawn == SpawnObject.bomb && GameManager.instance.CurrentBombs < GameManager.instance.bombLimit)
            {
                bombSprite.gameObject.SetActive(true);
                active = true;
            }
            else if (object2Spawn == SpawnObject.health && GameManager.instance.CurrentLife < GameManager.instance.startingLives)
            {
                active = true;
                healthSprite.gameObject.SetActive(true);
            }
            transform.position = spawnPlaces[Random.Range(0,spawnPlaces.Count)].position;
            Invoke("SpawnObj", time2Spawn);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && active)
        {
            healthSprite.gameObject.SetActive(false);
            bombSprite.gameObject.SetActive(false);
            active = false;
            //GameManager.instance.AddItem(object2Spawn);
            Invoke("SpawnObj", time2Spawn);
        }
    }

}
