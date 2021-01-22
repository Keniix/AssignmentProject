using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
void OnTriggerEnter2D(Collider2D other)
    {
        //if the other object has a tag of player
        if(other.tag == "Character")
        {
            //create an instance of the player script
            Move Character = other.GetComponent<Move>();
            //if player was found
            if(Character!= null)
            {
		    Character.SpeedBoostActive();
            }
        }
    Destroy(this.gameObject);
    }


}
