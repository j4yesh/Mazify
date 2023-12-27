using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slideBACK : MonoBehaviour
{
     public Text sliderText;
   public Slider mySlider;
   [SerializeField]
   public backtracking_algo mg;
   public void SliderChange(float Value)
    {
        float localValue = Value; // Scale the value to fit the desired range [0, 0.5]
        sliderText.text = Value.ToString("0.0") + "x";

        // Map the localValue from [0, 0.5] to [0, 0.5]
        localValue = MapValue(localValue, 0, 2f, 0, 0.5f);
        mg.DELAY = 0.5f - localValue; // Adjust mg.DELAY based on the mapped value
        Debug.Log("mg.DELAY: " + mg.DELAY);
    }

    private float MapValue(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        value = Mathf.Clamp(value, inputMin, inputMax);
        float mappedValue = outputMin + (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin);

        return mappedValue;
    }
}
