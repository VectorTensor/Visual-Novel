using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    Button back ; 
    
    void Start()
    {
         back = gameObject.GetComponent<Button>();
         back.onClick.AddListener(backHandler);

        
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
    void backHandler(){
        SceneManager.LoadScene(MainData.prevScene,LoadSceneMode.Single);
    }
}
