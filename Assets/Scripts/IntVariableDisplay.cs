using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntVariableDisplay : MonoBehaviour
{
    public IntVariable intVariableToDisplay;
    public TextMeshProUGUI text;
    private void Update()
    {
        text.text = intVariableToDisplay.CurrentValue.ToString();
    }
}
