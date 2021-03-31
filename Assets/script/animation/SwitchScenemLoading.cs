using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScenemLoading : MonoBehaviour
{
    public AsyncOperation Async;
    public Slider A;
    void Update()
    {
        A.value = Async.progress;
    }
}
