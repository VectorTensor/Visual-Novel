using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(quitListener);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void quitListener(){
        Application.Quit();
    }
}
