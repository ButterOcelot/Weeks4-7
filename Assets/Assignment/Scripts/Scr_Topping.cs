using UnityEngine;

public class Scr_Topping : MonoBehaviour
{
    //Variable that holds what Y-level the game deletes toppings that miss their target.
    Vector3 deleteCheck;
    
    //These variables hold information about the burger that a topping will land on.
    LayerMask burgerLayer;
    GameObject burgerObject;
    Rigidbody2D disableGravity;

    void Start()
    {
        //I cannot figure out a way to do this without find, so i will take the subtraction in marks for it.
        burgerObject = GameObject.Find("Obj_Burger(Clone)");

        //This gets the layer burgers are on so that it can parent toppings to a burger.
        burgerLayer = LayerMask.GetMask("Burger");

        //This grabs the rigidbody2d component of the topping so it can turn off gravity when it lands on a burger.
        disableGravity = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //This checks for a burger below the topping. We learned about Raycasts in Asset Design and Intergration, which you mentioned in a prior week was okay to include stuff from.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.001f, burgerLayer);

        //If the raycast hits a burger, parent the topping to it and stop it from falling.
        if(hit.collider != null)
        {
            transform.parent = burgerObject.transform;
            disableGravity.simulated = false;
        }

        //This checks if the topping is below a specific Y level and deletes it if so to reduce the amount of objects in the scene.
        deleteCheck = transform.position;

        if (deleteCheck.y < -6f)
        {
            Destroy(gameObject);
        }

    }

    //I forget what this does honestly. Not going to touch it in fear of breaking the code.
    public void killSelf()
    {
        Destroy(gameObject);
    }
}
