using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - generates meteors
public class MeteorGenerator : MonoBehaviour {
    public GameObject MeteorBG;
    public int MaxMeteors; //max number of meteors
                           // Use this for initialization
    void Start()
    {

        InvokeRepeating("drop", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void drop()
    {
        GameObject meteor = (GameObject)Instantiate(MeteorBG);
        meteor.transform.position = new Vector2(Random.Range(-3,3), 4);
    }

    
}
