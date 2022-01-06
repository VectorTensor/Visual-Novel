using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    Button button;
    AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(buttonHandler);
        
    }
    void buttonHandler(){
        Slider slider = GameObject.Find("Slider").GetComponent<Slider>();
        float data = slider.value;
        SettingsFormat sf = new SettingsFormat(data);
        SettingsController.DataSet(sf); // Save the settings to a file
        SettingsController.setSettings(sf);// Set the settings in the variable
        backgroundMusic = GameObject.Find("SoundSystem").GetComponent<AudioSource>();
        backgroundMusic.volume = sf.volume;
      //  Debug.Log("Settings saved");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
