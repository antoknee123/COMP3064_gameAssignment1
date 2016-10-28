using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls background behaviour 
public class BackgroundController : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Transform _transform;
    private Vector2 _currentPosition;

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.transform;
        _currentPosition = _transform.position;
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        _currentPosition = _transform.position;
        _currentPosition -= new Vector2(speed, 0);
        _transform.position = _currentPosition;
        if (_currentPosition.x <= -7.77f)
        {
            Reset();
        }

    }
    //resets background position
    public void Reset()
    {
        _currentPosition = new Vector2(7.77f, 0.14f);
        _transform.position = _currentPosition;
    }
}
