using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Move _character;


    // Start is called before the first frame update
void OnTriggerEnter2D(Collider2D other)
    {
        
        //if the other object has a tag of player
        if(other.tag == "Character")
        {
            //create an instance of the player script
            _character = other.GetComponent<Move>();
            //if player was found
            if(_character!= null)
            {
		        _character.SpeedBoostActive();
            }
        }
        Destroy(this.gameObject);
    }


}
