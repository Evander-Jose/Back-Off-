using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public FloatVariable currentHealth;
    public FloatVariable maxHealth;
    [Space]
    [Range(0f, 1f)] public float flashPercentage;
    public float flashRate;
    public Color flashColor1;
    public Color flashColor2;
    public Image fillBar;

    private void LateUpdate()
    {        
        //Debug.Log(percentage);
        slider.value = currentHealth.CurrentValue / maxHealth.CurrentValue;

        if(flashPercentage > slider.value)
        {
            fillBar.color = Color.Lerp(flashColor1, flashColor2, Mathf.Sin(flashRate*Time.time));
        }
    }
}
