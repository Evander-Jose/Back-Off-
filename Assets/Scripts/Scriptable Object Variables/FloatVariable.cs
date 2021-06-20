using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable Object/Float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value; //This one's default.
    private float currentvalue;
    [SerializeField] private bool constant;
    [SerializeField] private bool saveFromPlaymode;
    public float CurrentValue
    { 
        get { return currentvalue; }
        
        set 
        {
            if (constant == false)
                currentvalue = value;
            else
                Debug.LogError("You are trying to modify a constant variable!");
        }
    }

    private void OnEnable()
    {
        currentvalue = value;
    }

}
