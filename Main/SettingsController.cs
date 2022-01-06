using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class SettingsFormat 
{
    // Add the data stored in the settings you can add more settings in the future 
    public float volume;
    public SettingsFormat(float v){
        volume = v;
    }
}
public class SettingsController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource backgroundMusic; 
    
    void Start()
    {
        // As soon as the seen is loaded the data is obtained from the file and then the respective gameObject are used to set the setting
        // Check if there is already an instance of the audio
        if (GameObject.Find("SoundSystem")== null){

        // Create a gameobject
        GameObject audioObject = new GameObject("SoundSystem");
        
        backgroundMusic = audioObject.AddComponent<AudioSource>();
        backgroundMusic.clip = Resources.Load<AudioClip>("Sounds/Music/Naruto - Sasuke - Destiny");
        
        DontDestroyOnLoad(audioObject);
       // Debug.Log(backgroundMusic.clip);
        backgroundMusic.Play();
        //backgroundMusic.volume = 0.7f;

      //  SettingsData.volume = 0.5f; 
        DataGet(); // Disable for testing
        backgroundMusic.volume = SettingsData.volume;

        
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public static void DataSet(SettingsFormat sf){
            // write code to save the settings data to the file 
            // Write code to set the settings first
            setSettings(sf);
           string path = Application.persistentDataPath+"/Settings/";
        if (!Directory.Exists(path)){
            Directory.CreateDirectory(path);

        }

            
        FileStream file = File.Open(path+"settings.bin",FileMode.Create); 

        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file,sf);


        
    }
    public static void setSettings(SettingsFormat sf)
    {
        // Set the data of the settings to the script that stores the data of the settings in the game
        SettingsData.volume = sf.volume;
        
    }
    void DataGet(){
        // get settings data from the file and set the settings in settingsdata
        
             string path = Application.persistentDataPath+"/Settings/";
        if (!Directory.Exists(path)){
            return ;
        }
        FileStream file = File.Open(path+"settings.bin",FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        SettingsFormat sf = formatter.Deserialize(file) as SettingsFormat;
        // Write code to set the data ====> done   
        setSettings(sf);

    }
}
