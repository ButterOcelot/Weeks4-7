using UnityEngine;

public class Scr_BeltRotator : MonoBehaviour
{
    //Stores rotation data
    Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spins the wheels on the conveyer belt.
        rotation = transform.eulerAngles;
        rotation.z -= 15f * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
