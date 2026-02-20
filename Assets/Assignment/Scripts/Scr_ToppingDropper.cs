using UnityEngine;

public class Scr_ToppingDropper : MonoBehaviour
{
    //holds the topping object.
    public GameObject objectToSpawn;

    //handles the delay between when you can and cant spawn a new topping.
    public float waitDuration = 3f;
    public bool canSpawn = true;
    public bool timerBool = false;
    public float waitProgress = 0f;

    void Start()
    {

    }

    void Update()
    {
        //checks if a topping has been spawned, if so, activate the cooldown timer.
        if(canSpawn == false)
        {
            waitProgress += Time.deltaTime;
        }
        
        //if the cooldown is finished, reset it and allow the player to drop a new topping.
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

    //Code the spawns a topping when the UI button is pressed.
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
