using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls enemy behaviour 
public class EnemyControl : MonoBehaviour {
    GameObject scoreUITextGO; //reference to the text ui game object
    public GameObject ExplosionGO; // explosion prefab
    float speed;
	// Use this for initialization
	void Start () {

        speed = 2f;//set speed
        //get the score text ui
        scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {
        //get the enemy current position
        Vector2 position = transform.position;
        //compute the enemy new position
        position = new Vector2(position.x - speed * Time.deltaTime, position.y );
        //update the enemy position
        transform.position = position;


        //if the enemy went outside the screen on the bottom, then destroy the enemy
            if(transform.position.x < -5)
        {

            Destroy(gameObject);

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        // detect collisoon of the enemy ship with the player ship or with a players bullet
        if((col.gameObject.tag == "PlayerShipTag") )
        {

            PlayExplosion();
            
            Player.Instance.Lives -= 1;
           Destroy(gameObject);

        }
        // detect collison of the meteor with player bullet
        if ( col.gameObject.tag == "PlayerBulletTag")
        {
            PlayExplosion();
            Player.Instance.Points += 10;
            //destroy this meteor
           Destroy(gameObject);

        }


    }
    void PlayExplosion()
    {


        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;



    }
}
