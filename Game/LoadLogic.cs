using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadLogic : MonoBehaviour
{
    Button button ; 
    // Start is called before the first frame update
    void Start()

    {
        
        button = GetComponent<Button>();
        button.onClick.AddListener(loadListener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadListener(){
       // Debug.Log(gameObject.name);
        if (gameObject.name =="Save")
        {
        //Debug.Log("save is jere");
        MainData.LorS = false;        
        }
        else{
         //   Debug.Log("Load is here");
        MainData.LorS = true;        

        }
        SceneManager.LoadScene(3,LoadSceneMode.Single);
    }
}
