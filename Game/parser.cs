using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Line {
    public string Name;
    public string Dialogue;
    public int pose;
    public Line(string n, string d, int p){
        Name = n;
        Dialogue = d;
        pose = p;
    }
}
public class parser : MonoBehaviour
{
    public List<Line> Lines= new List<Line>(); 
    // Start is called before the first frame update
    void Start()
    {

    }
   public  void BeginParse(int Scene)
    {
       string path= "Assets/Resources/Dialogue/";
       string data;
       Lines.Clear();
       StreamReader fs = new StreamReader(path+"Dialogue"+Scene.ToString()+".txt");
       using (fs)
       {
           do {
                data= fs.ReadLine();
                if ( data !="$$" )
                {
                    string[] data_values = data.Split('|');
                    Line temp = new Line(data_values[0],data_values[1],Int32.Parse(data_values[2]));
                    Lines.Add(temp);

                    
                }

        }while(data!= "$$");
          

       }
 fs.Close();
// Debug.Log(" from parser.cs number of lines ");
//Debug.Log(Lines.Count);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public  string GetName(int num )
    {
        if (num<=Lines.Count)
        {
            return Lines[num-1].Name;
        }
        return "";

    }
     public string GetDialogue(int num)
    {
        if (num<= Lines.Count)
        {
            return Lines[num-1].Dialogue;

        }
        return "";
    }

     public int GetPose(int num)
    {
        if (num <= Lines.Count)
        {
            return Lines[num-1].pose;
        }
        return 0;
    }



}


























