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
    // Update is called once per frame

    void Start ()
    {
        scoreAmount =0f;
        pointIncreasedPerSecond=1.5f;
    }

    void Update()
    {
        scoreText.text =scoreAmount.ToString("0");
        scoreAmount +=pointIncreasedPerSecond *Time.deltaTime;
    }

}
