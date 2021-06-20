using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public FloatVariable currentHealth;
    public FloatVariable maxHealth;

    private void LateUpdate()
    {
        
        //Debug.Log(percentage);
        slider.value = currentHealth.CurrentValue / maxHealth.CurrentValue; ;
    }
}
