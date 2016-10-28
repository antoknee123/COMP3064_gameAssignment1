using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls player behaviour 
public class PlayerControl : MonoBehaviour
{

   
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;
    public GameObject ExplosionGO; //this is  explosion prefab

    //referece to the lives ui text
    public Text LivesUIText;
    const int MaxLives = 3; //max player lives
    int lives; //current player lives

    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInputX;
    private float _playerInputY;




    public float speed;

    public void Init()
    {

        lives = MaxLives;
        //update the lives UI text
        LivesUIText.text = lives.ToString();
        //reset the player position to the center of the screen
        transform.position = new Vector2(0, 0);
        // set this player game object to active
        gameObject.SetActive(true);

    }
    // Use this for initialization
    void Start()
    {
        _transform = gameObject.transform;
        _currentPosition = _transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //fire bullets when the spacebar is pressed
        if (Input.GetKeyDown("space"))
        {


            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position; //set the bullet initial position

            //instantiate the second bullet

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = BulletPosition02.transform.position; //set the bullet initial position

        }
        //Get user input
        _playerInputY = Input.GetAxis("Vertical");
        _playerInputX = Input.GetAxis("Horizontal");
        _currentPosition = _transform.position;

        //if up arrow key is pressed, player up
        if (_playerInputY > 0)
        {
            _currentPosition += new Vector2(0, speed);
        }
        //if down arrow key is pressed, player down
        if (_playerInputY < 0)
        {
            _currentPosition -= new Vector2(0, speed);
        }
        //if right arrow key is pressed, player right
        if (_playerInputX > 0)
        {
            _currentPosition += new Vector2(speed, 0);
        }
        //if left arrow key is pressed,  player left
        if (_playerInputX < 0)
        {
            _currentPosition -= new Vector2(speed, 0);

        }
        checkBound();
        _transform.position = _currentPosition;
    }
    //bounds for player
    private void checkBound()
    {
        if (_currentPosition.x < -3.8f)
        {
            _currentPosition.x = -3.8f;
        }
        if (_currentPosition.x > 3.6f)
        {
            _currentPosition.x = 3.6f;
        }
        if (_currentPosition.y < -2.8f)
        {
            _currentPosition.y = -2.8f;
        }
        if (_currentPosition.y > 2.8f)
        {
            _currentPosition.y = 2.8f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //collision with enemy
        if (other.gameObject.tag == "Enemy")
        {
            Player.Instance.Lives -=1;
            Debug.Log("Collision with" + other.gameObject.tag);
            EnemyControl enemy = other.gameObject.GetComponent<EnemyControl>();
            if (enemy != null)
            {
                GameObject ex = Instantiate(ExplosionGO);
                ex.transform.position = enemy.transform.position;
   
            }
           

        }
        if (other.gameObject.tag == "EnemyBulletTag")
        {  //collision with enemy bullet
            Player.Instance.Lives -= 1;
            Debug.Log("Collision with" + other.gameObject.tag);
            EBullet eBullet = other.gameObject.GetComponent<EBullet>();
            if (eBullet != null)
            {
                GameObject ex = Instantiate(ExplosionGO);
                ex.transform.position = eBullet.transform.position;

            }
        }
        if (other.gameObject.tag == "MeteorTag")
        { //collision with meteor
            Player.Instance.Lives -= 1;
            Debug.Log("Collision with" + other.gameObject.tag);
            Meteor meteor = other.gameObject.GetComponent<Meteor>();
            if (meteor != null)
            {
                GameObject ex = Instantiate(ExplosionGO);
                ex.transform.position = meteor.transform.position;

            }
        }
    }

}






