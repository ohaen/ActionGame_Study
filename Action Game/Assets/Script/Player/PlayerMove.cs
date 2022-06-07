using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    public bool canMove { get; set; } = true;
    
    public Camera _playerCamera;

    private Animator _playerAnimator;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Vector3 _moveVec;

    void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            Move();
            LookAtMouse();
        }
    }

    void Move()
    {
        _moveVec = new Vector3(_playerInput.horizontal, 0, _playerInput.vertical).normalized;
        _rigidbody.velocity = _moveVec * moveSpeed * Time.deltaTime;

        bool isRun;
        isRun = _moveVec.magnitude > 0 ? true : false;
        _playerAnimator.SetBool("Run", isRun);
    }

    void LookAtMouse()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }

    public void StopMove()
    {
        canMove = false;
        _rigidbody.velocity = Vector3.zero;
        _playerAnimator.SetBool("Run", false);
    }

    public void ResetMove()
    {
        canMove = true;
    }
}
