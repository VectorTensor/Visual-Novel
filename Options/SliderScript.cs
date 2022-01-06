using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript: MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    void Start()
    {
        Debug.Log(SettingsData.volume);
        slider =    gameObject.GetComponent<Slider>();
        slider.value = SettingsData.volume;



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
