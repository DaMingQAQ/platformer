using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Win()
    {
        text.text = "YOU WIN";
    }
}
