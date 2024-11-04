using UnityEngine;

// Static UI > Phonics Board

public class Phonics : MonoBehaviour
{
    public AudioSource phonetic;
    public AudioClip[] buttonSounds;

    public void PlaySound(int AudioClipIndex)
    {
        phonetic.clip = buttonSounds[AudioClipIndex];
        phonetic.Play(); // assigned to each btn
    }
}
