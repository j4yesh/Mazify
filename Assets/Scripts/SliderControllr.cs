using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderControllr : MonoBehaviour
{   
    public Text sliderText;
   public Slider mySlider;
   [SerializeField]
   public MazeGen mg;
   void Start(){
    SliderChange(3.8f);
   }
   public void SliderChange(float Value)
    {
        float localValue = Value; // Scale the value to fit the desired range [0, 0.5]
        sliderText.text = localValue.ToString("0.0") + "x";

        mg.DELAY =0.5f-localValue;
        // Map the localValue from [0, 0.5] to [0, 0.5]
        // Debug.Log(localValue+"localValues");
        // localValue = MapValue(localValue, 0, 5f, 0, 0.5f);
       
        // Debug.Log(0.5f-localValue);
    }

    private float MapValue(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        value = Mathf.Clamp(value, inputMin, inputMax);

        if (inputMax - inputMin == 0)
        {
            Debug.LogWarning("Input min and max are equal; division by zero avoided.");
            return outputMin;
        }

        float mappedValue = outputMin + (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin);

        return mappedValue;
    }
}
