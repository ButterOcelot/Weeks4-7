using UnityEngine;

public class Scr_Flipper : MonoBehaviour
{

    bool move = false;
    float direction = 1f;
    float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.position += direction * transform.right * speed * Time.deltaTime;
        }
    }


    public void OnMoveClick()
    {
        move = true;
    }

    public void OnStopClick()
    {
        move = false;
    }

    public void OnFlipClick()
    {
        direction *= -1f;
    }
}
