using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoungVakue : MonoBehaviour
{
    AudioSource Audio;
    public string Name;
    public float TargetTime;
    float Target;
    int a = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey(Name))
        {
            PlayerPrefs.SetFloat(Name, 1);
        }
        Audio = GetComponent<AudioSource>();
        Target = PlayerPrefs.GetFloat(Name);
        Audio.volume = Target;
        a = 1;
        this.enabled = false;
    }

    private void Update()
    {
        if (a == 0)
        {
            Audio.volume += Time.deltaTime;
            if (Audio.volume >= Target)
            {
                Audio.volume = Target;
                a = 1;
                this.enabled = false;
            }
        }
        else
        {
            Audio.volume -= Time.deltaTime;
            if (Audio.volume <= 0)
            {
                Audio.volume = 0;
                this.enabled = false;
            }
        }
    }
    public void Change()
    {
        Audio.volume = PlayerPrefs.GetFloat(Name);
    }
}
