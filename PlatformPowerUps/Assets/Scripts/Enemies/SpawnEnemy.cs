using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform spawnPoint = gameObject.transform.Find("SpawnPoint");

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            enemy.GetComponent<Enemy>().speed = 10;
            enemy.GetComponent<Enemy>().damage = 100;

            Destroy(gameObject);
        }
    }
}
