using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ProgressionManager : MonoBehaviour
{
    public IntVariable currentScore;
    public List<ProgressionMilestone> milestones = new List<ProgressionMilestone>();

    private void Update()
    {
        StartCoroutine(CheckAndUpdateProgressionMilestones());
    }

    private IEnumerator CheckAndUpdateProgressionMilestones()
    {
        for(int i = 0; i < milestones.Count; i++)
        {
            if(!milestones[i].milestoneCrossed)
            {
                if(milestones[i].milestone < currentScore.CurrentValue)
                {
                    //Mark the mileston as crossed:
                    milestones[i].milestoneCrossed = true;
                    milestones[i].onMilestoneCrossed.Invoke();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}

[System.Serializable]
public class ProgressionMilestone
{
    public UnityEvent onMilestoneCrossed;
    public int milestone;
    public bool milestoneCrossed;
}