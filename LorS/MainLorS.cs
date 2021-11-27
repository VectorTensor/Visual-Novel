using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
// Class that formats the gamedata
//
[System.Serializable]
class SaveData {
  public List<int> Choices;  
  public int currentScene; 
  public int LineNum;
  public SaveData(List<int> c , int cs, int l)
  {
      Choices = c;
      currentScene = cs;
      LineNum = l;
  }
}

public class MainLorS: MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Text welcome = GameObject.Find("welcome").GetComponent<Text>();// Finding the text object
        string path = Application.persistentDataPath;

        if (MainData.LorS){ // If the its load scene then make text load or else make text 
           welcome.text = "Load";
           
            FindFiles(path);
            
     }
        else{
            welcome.text = "Save";
                
            FindFiles(path);
            // for loop for adding handler to all the buttons 

            int i;
            for ( i=0; i<(17-1);i++ )
            {
                string x= (i+1).ToString();
                Button my_button= GameObject.Find("Load"+x).GetComponent<Button>();
                my_button.onClick.AddListener(saveButtonHandler);

            }
        }
        

    }
    void saveButtonHandler()
    {
        string filename = EventSystem.current.currentSelectedGameObject.name;
        if (!EventSystem.current.currentSelectedGameObject.GetComponent<Empty>().IsEmpty)
        {

            // Write code for a dialog box warning you will override the current data
           saveWarning sw = GameObject.Find("warningparent").transform.Find("warning").gameObject.GetComponent<saveWarning>();
           sw.makeVisible();// The warning box is made active
           // code for adding button handler for yes and no
           // for yes yeshandler --> saves the file 
           // for no nohandler --> deactivates the warning box

           Button yes = GameObject.Find("choice1").GetComponent<Button>();
           Button no = GameObject.Find("choice2").GetComponent<Button>();
           yes.onClick.AddListener(()=>yeshandler(filename));
           no.onClick.AddListener(nohandler);
        }
        else{
        filename= Regex.Replace(filename,"[^0-9]","");
        filename= "Save"+filename;
        Save(filename);

         }
    }
    void yeshandler(string filename)
    {
        filename= Regex.Replace(filename,"[^0-9]","");
        filename= "Save"+filename;
        Save(filename);

           saveWarning sw = GameObject.Find("warningparent").transform.Find("warning").gameObject.GetComponent<saveWarning>();
           sw.makeInvisible();// The warning box is made Inactive


    }
    void nohandler()
    {
           saveWarning sw = GameObject.Find("warningparent").transform.Find("warning").gameObject.GetComponent<saveWarning>();
           sw.makeInvisible();// The warning box is made Inactive
        
    }
    void Load(string filename )// This function loads the data from given filename

    {

        string path = Application.persistentDataPath +"/"+ filename;
        FileStream fs = File.Open(path,FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        SaveData  data = formatter.Deserialize(fs) as SaveData;
        fs.Close();


        
    }
    void Save(string filename) // This function Saves the data in a filename given 
    {
        
        SaveData data= new SaveData(GameData.Choices, GameData.currentScene, GameData.LineNum); //Instance of save file 
        string path = Application.persistentDataPath +"/"+ filename;
        FileStream fs = File.Open(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        
        formatter.Serialize(fs, data);
        fs.Close();


         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindFiles(string path){
       IEnumerable<string> files= Directory.EnumerateFiles(path);
        string filed;
       foreach (string file in files) // Here files in the save folder is looked and specific load is activated
        {
            
           filed= Regex.Replace(file, "[^0-9]","");
           Empty status = GameObject.Find("Load"+filed).GetComponent<Empty>();
           status.IsEmpty = false;
           Text loadname = GameObject.Find("Load"+filed).GetComponentInChildren<Text>();
           loadname.text = "Save"+filed;


        }
       

        




    }
}






























