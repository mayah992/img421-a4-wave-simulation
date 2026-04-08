using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class start_game : MonoBehaviour
{
    public List<GameObject> apples;

    // Start is called before the first frame update
    void Start()
    {
        SpawnApples();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnApples()
    {

        foreach (GameObject prefab in apples)
        {
            float randomX = Random.Range(-50f, 50f);
            float randomZ = Random.Range(70f, -60f);
            Vector3 randomPos = new Vector3(randomX, -0.38f, randomZ);
            Instantiate(prefab, randomPos, Quaternion.identity);
        }
    }
}
