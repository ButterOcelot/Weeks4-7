using Unity.VisualScripting;
using UnityEngine;

public class Scr_Burger : MonoBehaviour
{
    GameObject plateObject;
    LayerMask plateLayer;
    public GameObject topBun;
    Vector3 spawnPos;
    bool topBunSpawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plateObject = GameObject.Find("Obj_Plate");
        plateLayer = LayerMask.GetMask("Plate");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.001f, plateLayer);

        if(hit.collider == null)
        {
            Vector3 posBurg = transform.position;
            posBurg.x += 1f * Time.deltaTime;
            transform.position = posBurg;
        }
        if(hit.collider != null)
        {
            transform.parent = plateObject.transform;
            transform.position = plateObject.transform.position;

            Debug.Log(topBunSpawned);

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
