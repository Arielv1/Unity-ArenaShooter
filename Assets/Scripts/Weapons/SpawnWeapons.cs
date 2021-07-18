using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnWeapons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RiflePrefab;
    public GameObject GrenadePrefab;
    // public Vector3[] positions;
    public Vector3[] positions = new Vector3[] { 
        //new Vector3(10f,0.7f,-7f),
        //new Vector3(10.75f,0.7f,-16.5f),
        //new Vector3(30f,0.7f,-17f),
        //new Vector3(46.5f,0.7f,-23f),
        //new Vector3(44f,0.7f,13f),
        //new Vector3(25.5f,0.7f,10f),
        //new Vector3(24f,0.7f,-12.5f),
        //new Vector3(24f,3.5f,-8f),
        //new Vector3(16.5f,0.7f,-17f)
        // new Vector3(90.039f,7.531f,19.201f),

    };
    void Start()
    {
        for(int i = 0; i <2;i++)
        {
            int random = Random.Range(0,positions.Length);
            SpawnWeapon(positions[random],RiflePrefab);
            SpawnWeapon(positions[random],GrenadePrefab);

            var numbersList = positions.ToList();
            numbersList.Remove(positions[random]);
            positions = numbersList.ToArray();
            // SpawnRifle(positions[random])
        }
    }
    public void SpawnRifle(Vector3 position)
    {
        //Debug.Log(" SpawnRifle called in spawnWeapons Script with position: " + position);
        Instantiate(RiflePrefab,position,Quaternion.identity);
        // transform.position = position;
    }
    public void SpawnWeapon(Vector3 position,GameObject weapon)
    {
        //Debug.Log(" SpawnWeapon called in with position: " + position + " and weapon: " + weapon);
        Instantiate(weapon,position,Quaternion.identity);
    }
}
