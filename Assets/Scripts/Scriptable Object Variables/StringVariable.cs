using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Variable Object/String")]
public class StringVariable : ScriptableObject
{
    [SerializeField] private string value;
    public string CurrentValue { get; set; }

    private void OnEnable()
    {
        CurrentValue = value;
    }
}
