using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BarrelController : MonoBehaviour
{
    public List<Vector3> knivesPos = new List<Vector3>();
    public List<Quaternion> knivesRot = new List<Quaternion>();
    public List<GameObject> knives = new List<GameObject>();
    public GameObject objToSpawn;
    public GameObject failStateObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        for (int i = 0; i < 6; i++)
        {

            GameObject spawnedObject = Instantiate(objToSpawn, knivesPos[i], knivesRot[i]);
            knives.Add(spawnedObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }




}