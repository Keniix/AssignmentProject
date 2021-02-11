using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    private float _loadedHighScore;
    // Start is called before the first frame update
    void Start()
    {
        _loadedHighScore = PersistentData.data._highScore;
        highScoreText.text = "High Score: " + _loadedHighScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
