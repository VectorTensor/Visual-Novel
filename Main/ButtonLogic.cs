using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonLogic : MonoBehaviour
{
    Button button;
    // Button object

    // Start is called before the first frame update

    void Start()
    {

            button= GetComponent<Button>(); // Setting the button object equal to the button component of the object attached to script
        if (gameObject.name =="PLAY"){// Attaching the appropriate listener to the gameobject according to the name of the object 
            button.onClick.AddListener(playListener);
        }
        else if (gameObject.name == "LOAD"){
            button.onClick.AddListener(loadListener);
            

        }
        else if (gameObject.name == "Options"){

            button.onClick.AddListener(optionListener);
        }
        else if (gameObject.name == "Quit"){
            button.onClick.AddListener(quitListener);
        }
        else{
            Debug.Log("Unkown gameobject");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void playListener()// Listener for the play button
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        //Add the default gamedata to play game from begining 

    }
    void optionListener() // Listener for the option button
    {

        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }
    void loadListener() // Listener for the load button 
    {
        MainData.LorS = true;// LorS = True means Load is selected 

        SceneManager.LoadScene(3,LoadSceneMode.Single);
    }
    void quitListener() // Listener for the quit button
    {

            Application.Quit();
    }
    
}
