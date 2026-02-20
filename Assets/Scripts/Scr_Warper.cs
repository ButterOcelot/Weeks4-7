using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Scr_Warper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool shouldWarp = Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject();


        if (shouldWarp == true)
        {

            Vector3 currentMousePosition = Mouse.current.position.ReadValue();

            transform.position = currentMousePosition;
        }
    }
}
