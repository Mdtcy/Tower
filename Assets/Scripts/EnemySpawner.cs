using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    public float cd;

    private void Start()
    {
        StartCoroutine(ISpawn());
    }

    IEnumerator ISpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cd);
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject.Instantiate(enemy);
    }
}
