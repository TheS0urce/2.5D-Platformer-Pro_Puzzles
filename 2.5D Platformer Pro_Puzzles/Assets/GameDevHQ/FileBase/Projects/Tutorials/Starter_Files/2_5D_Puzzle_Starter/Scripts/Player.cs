using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _pushPower = 2.0f;

    private Vector3 _direction, _velocity;
    private bool _canWallJump = false;
    private Vector3 _wallSurfaceNormal;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL."); 
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (_controller.isGrounded == true)
        {
            _canWallJump = true;
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == false)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            if(Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
            {
                //velocity needs to equal surfacenormal of the wall
                _yVelocity += _jumpHeight;
                _velocity = _wallSurfaceNormal * _speed;
            }

            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //detect moving box
        //confirm it has a rigidbody

        Rigidbody rb = hit.collider.attachedRigidbody;

        if(hit.transform.tag == "MovingBox")
        {
            if(rb != null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
                rb.velocity = pushDirection * _pushPower;
            }

            if(hit.moveDirection.y < -0.3f)
            {
                return;
            }
        }

        //push power - declare valuable on top
        //calculate move direction
        //push - using moving box velocity

        //if not grounded && touching a wall
        if (_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            //we can wall jump
            _canDoubleJump = true;
        }
    }

    public void AddCoins()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int CointCount()
    {
        return _coins;
    }
}
