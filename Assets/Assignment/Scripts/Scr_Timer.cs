using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Timer : MonoBehaviour
{
    public GameObject squeezeBottle;
    public Slider timerSlider;
    float clockDuration;
    bool reset = false;
    Scr_ToppingDropper squeezeRef;
    private float timeWaiting = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        squeezeRef = squeezeBottle.GetComponent<Scr_ToppingDropper>();
        clockDuration = squeezeRef.waitDuration;
        timerSlider.maxValue = clockDuration;
        timerSlider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(reset);

        reset = squeezeRef.timerBool;

        if (reset == true)
        {
            timeWaiting = squeezeRef.waitProgress;
            timerSlider.value = squeezeRef.waitProgress;

            if (timeWaiting > clockDuration)
            {
                reset = false;
                timerSlider.value = 0f;
            }

        }

        if(reset == false)
        {
            timeWaiting = 0f;
            timerSlider.value = 0f;
        }
        

    }
}
