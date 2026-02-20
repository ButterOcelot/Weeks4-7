using UnityEngine;

public class Scr_BurgerOven : MonoBehaviour
{
    //Holds the burger object.
    public GameObject objectToSpawn;

    //Timer variables for the delay between patties.
    public float waitDuration = 45f;
    public float waitProgress = 0f;

    //Spawn location for the burger.
    Vector3 spawnLocation;

    //Stores the spawned burger.
    GameObject objectRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Setting the spawn location.
        spawnLocation.x = -8.16f;
        spawnLocation.y = -2.31f;
        spawnLocation.z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Delay timer increases always.
        waitProgress += Time.deltaTime;
        
        //if it finishes, reset it and spawn a burger.
        if (waitProgress > waitDuration)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnLocation, Quaternion.identity);
            objectRef = spawnedObject;
            waitProgress = 0f;
        }

    }
}
