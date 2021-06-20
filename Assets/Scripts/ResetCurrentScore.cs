using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCurrentScore : MonoBehaviour
{
    public IntVariable currentScore;

    private void Start()
    {
        currentScore.CurrentValue = 0;
    }
}
