using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightScore : MonoBehaviour
{
    public static int highScore = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.score > highScore)
        {
            highScore = Score.score;
        }
        GetComponent<UnityEngine.UI.Text>().text = "High Score: " + highScore.ToString();

    }
}
