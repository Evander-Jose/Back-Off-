using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SFX")]
public class SFX : ScriptableObject
{
    [Range(0f, 1f)] public float maxVolume;
    [Range(0f, 1f)] public float minVolume;
    [Space]
    [Range(-3f, 3f)] public float maxPitch;
    [Range(-3f, 3f)] public float minPitch;
    [Space]
    public AudioClip clip;

    public void PlaySFX()
    {
        GameObject newBlankSFXObject = new GameObject("SFX: " + clip.name);
        AudioSource audio = newBlankSFXObject.AddComponent<AudioSource>();

        audio.clip = clip;
        audio.volume = Random.Range(minVolume, maxVolume);
        audio.pitch = Random.Range(minPitch, maxPitch);

        audio.Play();
        Destroy(newBlankSFXObject, clip.length);
    }
}
