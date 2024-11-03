using UnityEngine;
using UnityEngine.UI;
public class Phonics : MonoBehaviour
{

    //public Button aBtn;
    public AudioSource phonetic;
    public AudioClip[] buttonSounds;

    public void PlaySound(int AudioClipIndex)
    {
        phonetic.clip = buttonSounds[AudioClipIndex];
        phonetic.Play();
    }

   
}
