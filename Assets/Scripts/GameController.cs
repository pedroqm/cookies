using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    private GameObject fadeImage;
    public Text textTime;
    private float timeGame;
    private bool travesura;

    public AudioClip musicaVuelta;
    private AudioSource musicSource;

    private void Awake()
    {
        fadeImage = GameObject.FindGameObjectWithTag("fadeImage");
        musicSource = gameObject.GetComponent<AudioSource>();
        travesura = false;
        timeGame = 0f;
    }

    private void Start()
    {

        if (fadeImage != null)
        {
            fadeImage.SetActive(false);
        }
    }

    private void Update()
    {
        timeGame = timeGame + Time.deltaTime;
        textTime.text = timeGame.ToString("f2");
        // textTime.text =  Time.fixedTime.ToString("f2");
    }
    public void Travesura()
    {
        if (!travesura)
        {
            Debug.Log("travesura");

            musicSource.clip = musicaVuelta;
            musicSource.loop = true;
            musicSource.Play();
            travesura = true;
        }
        
    }
}
