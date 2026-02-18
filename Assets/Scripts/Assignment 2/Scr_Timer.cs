using UnityEngine;
using UnityEngine.UI;

public class Scr_Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float clockDuration;

    private float timeWaiting = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = clockDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timeWaiting += Time.deltaTime * 1;
        timerSlider.value = timeWaiting;

        if (timeWaiting > clockDuration)
        {
            Debug.Log("Time is up");
        }

    }
}
