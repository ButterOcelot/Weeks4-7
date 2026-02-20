using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Scr_TimerBurg : MonoBehaviour
{
    public GameObject oven;
    public Slider timerSlider;
    float clockDuration;
    Scr_BurgerOven ovenRef;
    private float timeWaiting = 0f;

    void Start()
    {
        //getting a reference to the oven so it can take it's timer and put it onto the slider.
        ovenRef = oven.GetComponent<Scr_BurgerOven>();
        clockDuration = ovenRef.waitDuration;
        timerSlider.maxValue = clockDuration;
        timerSlider.value = 0f;
    }

    void Update()
    {

        //put the oven's timer onto the slider, which then changes the fill of the clock sprite.
        timeWaiting = ovenRef.waitProgress;
        timerSlider.value = ovenRef.waitProgress;

        if (timeWaiting > clockDuration)
        {
            timeWaiting = 0f;
            timerSlider.value = 0f;
        }
    }
}
