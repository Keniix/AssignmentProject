using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    private GameManager _gameManager;
    // Update is called once per frame

    void Start ()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreAmount =0f;
        pointIncreasedPerSecond=1.5f;
    }

    void Update()
    {
        scoreText.text =scoreAmount.ToString("0");
        scoreAmount +=pointIncreasedPerSecond *Time.deltaTime;
    }

    public void persistHighScore()
    {
        _gameManager.SaveHighScore(scoreAmount);
    }

}
