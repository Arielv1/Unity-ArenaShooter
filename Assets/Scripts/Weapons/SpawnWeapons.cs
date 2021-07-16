using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RiflePrefab;
    public GameObject GrenadePrefab;
    // public Vector3[] positions;
    public Vector3[] positions = new Vector3[] { 
        new Vector3(10f,0.7f,-7f),
        new Vector3(24f,3.2f,-7f),
        new Vector3(14.3f,0.3f,12f)
        // new Vector3(14.326f,0.32f,12.08f)

    };
    void Start()
    {
        for(int i = 0; i <2;i++)
        {
            int random = Random.Range(0,positions.Length);
            SpawnWeapon(positions[random],RiflePrefab);
            SpawnWeapon(positions[random],GrenadePrefab);

            // SpawnRifle(positions[random])
        }
    }
    public void SpawnRifle(Vector3 position)
    {
        Debug.Log(" SpawnRifle called in spawnWeapons Script with position: " + position);
        Instantiate(RiflePrefab,position,Quaternion.identity);
        // transform.position = position;
    }
    public void SpawnWeapon(Vector3 position,GameObject weapon)
    {
        Debug.Log(" SpawnWeapon called in with position: " + position + " and weapon: " + weapon);
        Instantiate(weapon,position,Quaternion.identity);
    }
}
