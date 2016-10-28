using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO; //this is our enemy bullet
    public GameObject Enemy;
	// Use this for initialization
	void Start () {
        //fire an enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
        InvokeRepeating("fireBullet", 0f, 1f);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

   
    void fireBullet()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
        bullet.transform.position = Enemy.transform.position;
    }
}
