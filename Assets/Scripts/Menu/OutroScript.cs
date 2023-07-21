using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioS;
    public AudioClip bossDefeatedSound;
    public AudioClip finalAudio;
    void Start()
    {
        audioS= GetComponent<AudioSource>();
        StartCoroutine(FinalEvent());
    }

    private IEnumerator FinalEvent()
    {
        audioS.clip= bossDefeatedSound;
        audioS.Play();
        yield return new WaitForSeconds(audioS.clip.length + 1.6f);
        audioS.clip = finalAudio;
        audioS.Play();
        yield return new WaitForSeconds(audioS.clip.length + 1.6f);
        SceneManager.LoadScene("MenuInicio", LoadSceneMode.Single);
    }
}
