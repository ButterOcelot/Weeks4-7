using UnityEngine;

public class Scr_BeltRotator : MonoBehaviour
{
    Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.eulerAngles;
        rotation.z -= 15f * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
