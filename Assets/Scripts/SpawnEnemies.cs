using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies;

    private void Awake()
    {
  
        if (enemies == null || enemies.Count == 0)
        {
            GameObject[] ressourcesEnemies = Resources.LoadAll<GameObject>("Enemies/Prefabs"); 
            foreach(GameObject enemy in ressourcesEnemies)
            {
                if (enemy.tag == "Enemy")
                {
                    enemies.Add(enemy);
                }
            
            }            
        }
        
    }

    private void Start()
    {
        StartCoroutine(spawnEnemies());     
    }

    private IEnumerator spawnEnemies()
    {
        while (true) { 
            Instantiate(enemies[Random.Range(0,enemies.Count)],new Vector3(14f,-3.9f,0),Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f,4f));
            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector3(14f, -3.9f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f,2f));
        }
    }
}
