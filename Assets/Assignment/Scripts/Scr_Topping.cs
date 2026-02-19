using UnityEngine;

public class Scr_Topping : MonoBehaviour
{
    Vector3 deleteCheck;
    LayerMask burgerLayer;
    GameObject burgerObject;
    Rigidbody2D disableGravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        burgerObject = GameObject.Find("Obj_Burger");
        burgerLayer = LayerMask.GetMask("Burger");
        disableGravity = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.001f, burgerLayer);

        if(hit.collider != null)
        {
            transform.parent = burgerObject.transform;
            disableGravity.simulated = false;
        }
        else
        {
            //Debug.Log("no burger, sad");
        }

        deleteCheck = transform.position;

        if (deleteCheck.y < -6f)
        {
            Destroy(gameObject);
        }

    }
}
