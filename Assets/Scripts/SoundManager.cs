using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _audioSource;
    private GameObject[] _musics;

    public AudioClip[] musicClips;

    private int _currentClipIndex = -1;

    private WaitForSeconds wait = new WaitForSeconds(6.5f);

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _musics = GameObject.FindGameObjectsWithTag("Music");

        if (_musics.Length >= 2)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlayVideo());
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = scene.buildIndex;

        if (sceneIndex == 1)  // 인트로
        {
            PlayMusic(0);
        }
        //else if (sceneIndex == 1) // 스테이지1
        //{
        //    PlayMusic(0);
        //}
    }

    private void PlayMusic(int musicClip)
    {
        if (musicClip == _currentClipIndex)
        {
            return;
        }

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.clip = musicClips[musicClip];
        _audioSource.Play();

        _currentClipIndex = musicClip;
    }

    private IEnumerator WaitForPlayVideo()
    {
        yield return wait;
        PlayMusic(0);
    }
}