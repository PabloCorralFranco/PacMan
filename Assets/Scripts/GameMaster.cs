using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public float[] scatterTimes, chaseTimes;
    public float frightenedTime;
    public bool frightened;
    public int maxLife, totalCoins;
    public GameObject spawnPlayer;
    public GameObject[] spawnEnemy;

    private Enemy[] enemies;
    private Player player;
    private Interface iface;
    private Inventory inv;
    private bool inChase;

    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
        player = FindObjectOfType<Player>();
        inv = FindObjectOfType<Inventory>();
        iface = FindObjectOfType<Interface>();
        iface.changeLives(player.life);
        Debug.Log(enemies.Length);
        inChase = true;
        StartCoroutine("gameScheme");
    }

    void Update()
    {
        if (inv.getTotalCoins() == totalCoins) iface.winning();
    }

    private IEnumerator gameScheme()
    {
        Debug.Log("GAME MASTER START");
        int i = 0;
        while(i < scatterTimes.Length && i < chaseTimes.Length)
        {
            if (inChase && !frightened)
            {
                yield return new WaitForSeconds(chaseTimes[i]);
                inChase = false;
            }
            else if(!frightened)
            {
                for (int j = 0; j < enemies.Length; j++)
                {
                    enemies[j].roaming = true;
                    enemies[j].StartCoroutine("scatter", scatterTimes[i]);
                }
                yield return new WaitForSeconds(scatterTimes[i]);
                for (int j = 0; j < enemies.Length; j++)
                {
                    enemies[j].roaming = false;
                    enemies[j].StopAllCoroutines();
                }
                i += 1;
                inChase = true;
            }
            yield return null;
        }
        Debug.Log("End");
        yield return null;
    }


    public void frightenedState()
    {
        frightened = true;
        for (int i = 0; i < enemies.Length; i++)
        {
            //enemies[i].StopAllCoroutines();
            enemies[i].StartCoroutine("frightened", enemies[i].frightenedTime);
        }
    }



    public void substractLife()
    {
        player.life -= 1;
        if(player.life <= 0)
        {
            Debug.Log("Perdida de la partida");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            iface.changeLives(player.life);
            player.transform.position = spawnPlayer.transform.position;
            spawnAndResetEnemies();
        }
    }

    private void spawnAndResetEnemies()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = spawnEnemy[i].transform.position;
            //enemies[i].StopAllCoroutines();
            enemies[i].roaming = false;

            if (enemies[i].knightName.Equals("Clyde") || enemies[i].knightName.Equals("Pinky"))
            {
                enemies[i].canExit = false;
                enemies[i].StartCoroutine("waitingTime", enemies[i].timeToWait);
            }
            else
            {
                enemies[i].canExit = true;
            }
        }
        //StopCoroutine("gameScheme");
        inChase = true;
        StartCoroutine("gameScheme");
    }

}
