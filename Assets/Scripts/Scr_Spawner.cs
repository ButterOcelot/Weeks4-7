using UnityEngine;

public class Scr_Spawner : MonoBehaviour
{
    //Holds the topping object.
    public GameObject objectToSpawn;

    public float waitDuration;
    public float destroyDuration;

    public float pacerSpeed;
    public Color pacerColour;

    float waitProgress = 0f;
    float destroyProgress = 0f;

    void Start()
    {
        
        

    }

    void Update()
    {
        waitProgress += Time.deltaTime;
        if(waitProgress > waitDuration)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            Scr_Pacer spawnedPacer = spawnedObject.GetComponent<Scr_Pacer>();
            spawnedPacer.speed = pacerSpeed;

            SpriteRenderer spawnedRender = spawnedObject.GetComponent<SpriteRenderer>();
            spawnedRender.color = pacerColour;


            Destroy(spawnedObject, destroyDuration);

            waitProgress = 0f;
        }

       
    }
}
