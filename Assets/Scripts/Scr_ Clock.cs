using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Clock : MonoBehaviour
{
    private int previousWaitTime;
    public float rotationSpeed;
    public AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z -= rotationSpeed * Time.deltaTime;

        if((int)currentRotation.z % 45 == 0)
        {
            
            int waitTime = (int)currentRotation.z;
            bool canPlay = true;

            if (currentRotation.z > previousWaitTime)
            {
                canPlay = false;
            }

            if (canPlay == true)
            {
                Debug.Log("This is an hour");
                audioSource.Play();
            }

            previousWaitTime = waitTime;

        }

       // Debug.Log(currentRotation.z);

        transform.eulerAngles = currentRotation;
    }
}
