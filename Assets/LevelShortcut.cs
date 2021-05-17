using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelShortcut : MonoBehaviour
{
    [SerializeField] string level1;
    [SerializeField] string levelBoss;
    [SerializeField] string level2;

    StopAudioSources stopAudios;

    private void Start()
    {
        stopAudios = GameObject.FindGameObjectWithTag("StopAudio").GetComponent<StopAudioSources>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            stopAudios.StopAllAudio();
            SceneManager.LoadScene(level1);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            stopAudios.StopAllAudio();
            SceneManager.LoadScene(levelBoss);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            stopAudios.StopAllAudio();
            SceneManager.LoadScene(level2);
        }
    }
}
