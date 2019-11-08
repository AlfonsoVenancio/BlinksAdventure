using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int startingLives = 3;
    public int bombLimit=3;
    public Player player;
    public GameObject[] lives;
    public TMP_Text bombsDisplay;

    public GameObject enemyPrefab;

    public GameObject ResetButton;

    int currentBombs;

    public int CurrentBombs
    {
        get
        {
            return currentBombs;
        }
    }

    int currentLife;

    public int CurrentLife
    {
        get
        {
            return currentLife;
        }
    }

    public List<Transform> spawnPlaces;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        //ResetButton.SetActive(false);
        currentLife = startingLives;
        currentBombs = 3;
        //EnemyDead();
    }

    /*
    public void AddItem(SpawnObject item2Add)
    {
        switch (item2Add)
        {
            case SpawnObject.health:
                currentLife++;
                if (currentLife <= lives.Length && currentLife > 0)
                {
                    lives[currentLife-1].SetActive(true);
                }
                break;
            case SpawnObject.bomb:
                currentBombs++;
                bombsDisplay.text = currentBombs+"";
                break;
            default:
                break;
        }
    }*/

    /*
    public void EnemyDead()
    {
        Invoke("SpawnEnemy", 3);
    }*/

    /*
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPlaces[Random.Range(0, spawnPlaces.Count)].position,Quaternion.identity,transform);
    }*/

    /*
    public void Damage()
    {
        currentLife--;
        if (currentLife<lives.Length && currentLife>=0)
        {
            lives[currentLife].SetActive(false);
        }
        if (currentLife<=0)
        {
            ResetButton.SetActive(true);
            player.gameObject.SetActive(false);
        }
    }*/

    /*
    public void UseBomb()
    {
        currentBombs--;

        bombsDisplay.text = currentBombs + "";
    }*/

    /*
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(0);
    }*/
}
