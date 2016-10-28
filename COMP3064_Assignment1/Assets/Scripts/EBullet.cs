using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls enemy bullet behaviour 

public class EBullet : MonoBehaviour {
    float speed;
    // Use this for initialization
    void Start()
    {
        speed = (8f);
    }

    // Update is called once per frame
    void Update()
    {
        // gets the the bullets current position
        Vector2 position = transform.position;
        //calculate the bullets new position
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        //update the bullets position
        transform.position = position;
       
        //if the bullet went outside the screen on the top, then destroy the bullet
        if (transform.position.x <-5)
        {

            Destroy(gameObject);


        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // detect collison of the players bullet with an enemy ship
        if (col.gameObject.tag == "PlayerShipTag")
        {
            Player.Instance.Lives -= 1;
           

        }

    }
}
