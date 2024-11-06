using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class FadeAudioSource : MonoBehaviour
{
    public AudioSource gameMusic;
    private float duration = 6f;
    private float targetVolume = 0f;

    void Start()
    {
        StartCoroutine(StartFade(gameMusic, duration, targetVolume));
    }

    public static IEnumerator StartFade(AudioSource gameMusic, float duration, float targetVolume)
    {
        yield return new WaitForSeconds(0.1f);
        float currentTime = 0;
        float start = gameMusic.volume;
        Debug.Log("Starting fade from " + start + " to " + targetVolume);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            gameMusic.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            Debug.Log("Current volume: " + gameMusic.volume);
            yield return null;
        }
        //yield break;
        gameMusic.volume = targetVolume;
        Debug.Log("Final volume set to: " + gameMusic.volume);
    }


}