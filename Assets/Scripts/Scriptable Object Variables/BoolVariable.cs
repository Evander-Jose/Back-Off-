using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable Object/Bool")]
public class BoolVariable : ScriptableObject
{
    [SerializeField] private bool value; //This one's default.
    private bool currentvalue;
    [SerializeField] private bool constant;
    [SerializeField] private bool saveFromPlaymode;

    public bool CurrentValue
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
        if (!saveFromPlaymode)
            currentvalue = value;

    }

}
