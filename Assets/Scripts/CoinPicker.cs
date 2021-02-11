using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPicker : MonoBehaviour
{
    private float coin = 0;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            points.coinAmount += 4;
            Destroy(other.gameObject);
        }

        else if(other.transform.tag == "Half Coin")
        {
            points.coinAmount += 2;
            Destroy(other.gameObject);
        }

        else if(other.transform.tag == "Boost")
        {
            points.coinAmount += 15;
        }

        else if(other.transform.tag == "Enemy")
        {
            points.coinAmount -= 10;
        }
    }


}
