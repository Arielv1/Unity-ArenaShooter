using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RiflePrefab;
    // public Vector3[] positions;
    public Vector3[] positions = new Vector3[] { 
        new Vector3(10f,0.7f,-7f),
        new Vector3(24f,3.2f,-7f),
        new Vector3(14.3f,0.3f,12f)
        // new Vector3(14.326,0.32,12.08)

    };
    void Start()
    {
        for(int i = 0; i <2;i++)
        {
            int random = Random.Range(0,positions.Length);
            SpawnRifle(positions[random]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnRifle(Vector3 position)
    {
        Debug.Log(" SpawnRifle called in spawnWeapons Script with position: " + position);
        Instantiate(RiflePrefab,position,Quaternion.identity);
        // transform.position = position;
    }
}
