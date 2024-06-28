using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float max_time;
    float time_left;
    void Start()
    {
        time_left = max_time;
    }
    void Reset()
    {
        time_left = max_time;
    }
    void Update()
    {
        if (time_left > 0) 
        {
            time_left -= Time.deltaTime;
            slider.value = time_left / max_time;
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }
}
