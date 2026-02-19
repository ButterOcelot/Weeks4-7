using UnityEngine;

public class Scr_ToppingDropper : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float waitDuration = 3f;
    public bool canSpawn = true;
    public bool timerBool = false;

    public float waitProgress = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn == false)
        {
            waitProgress += Time.deltaTime;
        }
        

        if (waitProgress > waitDuration)
        {

            if (canSpawn == false)
            {
                canSpawn = true;
                timerBool = false;
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
            timerBool = true;
        }
    }

   

}
