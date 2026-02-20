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

    void Start()
    {

        //getting references to the squeeze bottle to make sure it can apply it's timer onto the UI timer.
        squeezeRef = squeezeBottle.GetComponent<Scr_ToppingDropper>();
        clockDuration = squeezeRef.waitDuration;
        timerSlider.maxValue = clockDuration;
        timerSlider.value = 0f;
    }
    //put the squeeze bottle's timer onto the slider, which then changes the fill of the clock sprite.
    void Update()
    {

        //these if statements make sure the clock only visually updates when the bottle is on cooldown.
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
