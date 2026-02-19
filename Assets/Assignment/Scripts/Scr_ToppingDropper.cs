using UnityEngine;

public class Scr_ToppingDropper : MonoBehaviour
{
    public GameObject objectToSpawn;

    float waitDuration = 3f;
    bool canSpawn = true;

    float waitProgress = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitProgress += Time.deltaTime;

        if (waitProgress > waitDuration)
        {

            if (canSpawn == false)
            {
                canSpawn = true;
            }

            waitProgress = 0f;
           
        }
    }

    public void dropTopping()
    {
        if(canSpawn == true)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            canSpawn = false;
        }
    }

}
