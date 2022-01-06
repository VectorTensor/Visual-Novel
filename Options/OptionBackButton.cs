using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionBackButton : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    
    void Start()
    {
        button= gameObject.GetComponent<Button>();
        button.onClick.AddListener(buttonHandler);

        
    }

    // Update is called once per frame
    void buttonHandler(){
        SceneManager.LoadScene(MainData.prevScene,LoadSceneMode.Single);
    }
    void Update()
    {
        
    }
}
