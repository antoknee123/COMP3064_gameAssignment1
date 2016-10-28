using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls player bullet behaviour 
public class PlayerBullet : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        // gets the the bullets current position
        Vector2 position = transform.position;
        //compute the bullets new position
        position = new Vector2(position.x + speed * Time.deltaTime, position.y );
        //update the bullets position
        transform.position = position;
        //this is the top right point of the screen
        float maxX = 5f;

            //if the bullet went outside the screen on the top, then destroy the bullet
            if(transform.position.x > maxX)
        {

            Destroy(gameObject);


        }

	}

    void OnTriggerEnter2D(Collider2D col)
    {//if play bullet hits the enemy, score is increased by 20 (player has 2 bullets)
        if (col.tag=="Enemy")
        {
            Player.Instance.Points += 10;
            //Destroy(col.gameObject);
            //if player hits the meteor, score is increased by 20 (player has 2 bullets)
        }
        if (col.tag == "MeteorTag")
        {
            Player.Instance.Points += 10;
           // Destroy(col.gameObject);
        }

    }
}
