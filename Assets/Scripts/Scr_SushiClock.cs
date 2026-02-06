using UnityEngine;
using UnityEngine.UI;

public class Scr_SushiClock : MonoBehaviour
{
    public Slider sushiSlider;
    public float clockDuration;
    
    float timeWaiting = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sushiSlider.maxValue = clockDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timeWaiting += Time.deltaTime * 1;
        sushiSlider.value = timeWaiting;

        if (timeWaiting > clockDuration)
        {
            timeWaiting = 0f;
        }


    }
}
