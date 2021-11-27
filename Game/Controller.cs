using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    string Name;
    string dialogue;
    int pose;
    parser Parser;
    List<int> Choices;
    int LineNum;
    int currentScene;
    void Start()
    {
        Parser = GameObject.Find("Master").GetComponent<parser>();// Initializing parser and game data object
        
        Choices = GameData.Choices;// Getting the initial data from the gamedata
        LineNum = GameData.LineNum;
        currentScene = GameData.currentScene; 
        Parser.BeginParse(currentScene); // Parse the initial scene we get from the game data
       //Name= "Natsume"; //Debuging code
      // setPose(0) ;//Debugging code

            Name = Parser.GetName(LineNum);
            dialogue = Parser.GetDialogue(LineNum);

            pose = Parser.GetPose(LineNum);
            setName(Name); 
            setDialogue(dialogue);
            setPose(pose);
            LineNum++;
            GameData.LineNum = LineNum;


        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Name = Parser.GetName(LineNum);
            dialogue = Parser.GetDialogue(LineNum);

            pose = Parser.GetPose(LineNum);
            setName(Name); 
            setDialogue(dialogue);
            setPose(pose);
            LineNum++;
            GameData.LineNum = LineNum;
            

            
        }
        
        
    }
    void setName(string data)// This function sets the Name by changing the text of the name gameobject
    {
       Text name = GameObject.Find("Name").GetComponent<Text>(); 
       name.text = data;


    }
    void setDialogue(string data){// This function sets the dialogue 
        Text dialogue = GameObject.Find("Dialogue").GetComponent<Text>();
        dialogue.text = data;
    }
    void setPose(int data)// This function sets the current pose
    {
       string filename = Name+data.ToString();// Filename which is just the character name and the pose 
       Image character = GameObject.Find("Character").GetComponent<Image>();
       string path = "Characters/"+Name+"/"+filename;
       Sprite temp = Resources.Load<Sprite>(path); 
       Debug.Log(path);
       character.sprite = temp; 
    }

}
