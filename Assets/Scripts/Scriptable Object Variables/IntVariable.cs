using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable Object/Int")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int value; //This one's default.
    private int currentvalue;
    [SerializeField] private bool constant;
    [SerializeField] private bool saveFromPlaymode = false;
    public int CurrentValue
    { 
        get { return currentvalue; }
        
        set 
        { 
            if(constant == false)
                currentvalue = value; 
        }
    }

    private void OnEnable()
    {
        if (saveFromPlaymode)
            value = currentvalue;
        
        currentvalue = value;
    }

    public void ModifyIntValue(int amount)
    {
        currentvalue += amount;
    }
}
