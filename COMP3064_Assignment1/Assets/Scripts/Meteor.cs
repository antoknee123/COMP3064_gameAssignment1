using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls meteor behaviour 
public class Meteor : MonoBehaviour {

    float speed;
    // Use this for initialization
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // gets the the meteor current position
        Vector2 position = transform.position;
        //calculate the meteor new position
        position = new Vector2(position.x , position.y - speed * Time.deltaTime);
        //update the meteor position
        transform.position = position;

        //if the meteor went outside the screen on the top, then destroy the bullet
        if (transform.position.y < -5)
        {

            Destroy(gameObject);


        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
                // detect collison of the meteor with player ship
                if (col.gameObject.tag == "PlayerShipTag")
                {
                    Player.Instance.Points += 10;
                    //destroy this meteor
                    Destroy(gameObject);

                }
        if ( col.gameObject.tag =="PlayerBulletTag")
        {
            Player.Instance.Points += 10;
            //destroy this meteor
            Destroy(gameObject);

        }

    }
 }
