using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        // Cambiar la música según la escena cargada
        if (scene.name == "MainMenu")
        {
            PlayMusic("Menu");
        }
        else if (scene.name == "QuizScene")
        {
            PlayMusic("Quiz");
        }
        else if (scene.name == "FinalScene")
        {
            PlayMusic("Final");
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            if(musicSource != null)
            {
                musicSource.clip = s.clip;
                musicSource.loop = true;
                musicSource.Play();
            }
            else
            {
                Debug.Log("No hay music source");                
            }
            
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            if(sfxSource != null)
            {
                sfxSource.PlayOneShot(s.clip);
            }
            else
            {
                Debug.Log("No hay sfx Source");
            }
            
        }
    }
}
