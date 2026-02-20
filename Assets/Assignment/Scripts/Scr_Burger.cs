using Unity.VisualScripting;
using UnityEngine;

public class Scr_Burger : MonoBehaviour
{
    //Variables for storing the plate the burger gets parentd to, what layer its on, storing the top bun, spawning the top bun, and deleting the burger when its been around for long enough.
    public GameObject plateObject;
    LayerMask plateLayer;
    public GameObject topBun;
    Vector3 spawnPos;
    bool topBunSpawned = false;
    float deleteTimer = 0f;
    float deleteMax = 10f;

    void Start()
    {
        //I cannot figure out a way to do this without find, so i will take the subtraction in marks for it.
        plateObject = GameObject.Find("Obj_Plate");

        //This gets the layer the plate is on so that it can parent burger to the plate.
        plateLayer = LayerMask.GetMask("Plate");
    }

    void Update()
    {
        //checks if the burger is on the plate.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.001f, plateLayer);

        //if it isnt, move it to the right.
        if(hit.collider == null)
        {
            Vector3 posBurg = transform.position;
            posBurg.x += 1f * Time.deltaTime;
            transform.position = posBurg;
        }

        //if it is, parent it to the plate and teleport it on top.
        if (hit.collider != null)
        {
            transform.parent = plateObject.transform;
            transform.position = plateObject.transform.position;

            //once on the plate, start the delete timer.
            deleteTimer += Time.deltaTime;

            //when the timer is done, delete the burger to make room for a new one.
            if(deleteTimer > deleteMax)
            {
                deleteTimer = 0f;
                Destroy(gameObject);
            }

            //if the burger doesnt have a top bun, spawn one when its on the plate.
            if (topBunSpawned == false) 
            {
                spawnPos = transform.position;
                spawnPos.y += 15f;
                GameObject spawnedObject = Instantiate(topBun, spawnPos, Quaternion.identity);
                topBunSpawned = true;
            }
            
        }
    }
}
