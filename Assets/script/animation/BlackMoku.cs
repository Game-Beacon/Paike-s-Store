using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackMoku : MonoBehaviour
{

    Image I;
    public float speed;
    public string namee;
    public bool UseSlid;
    public float TargetTime;
    public SwitchScenemLoading loading;
    private void Start()
    {
        speed = 1 / TargetTime;
        I = GetComponent<Image>();
    }
    private void Update()
    {
        I.color += new Color(0, 0, 0, speed * Time.deltaTime);
        if (I.color.a >= 1)
        {
            if (UseSlid)
            {
                this.enabled = false;
                loading.gameObject.SetActive(true);
                loading.Async = SceneManager.LoadSceneAsync(namee);
            }
            else
            {
                this.enabled = false;
                SceneManager.LoadScene(namee);
            }
        }
    }



}
