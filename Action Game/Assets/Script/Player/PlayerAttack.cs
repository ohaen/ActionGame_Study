using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _playerAnimator;
    private PlayerMove _playerMove;

    private bool _isNextComboAttack = false;
    private int _comboStep = 0;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (_playerInput.mouseButtonDown)
        {
            if(_comboStep == 0)
            {
                _playerMove.StopMove();
                _playerAnimator.Play("Attack1");
                _comboStep = 1;
                return;
            }
            if(_comboStep != 0)
            {
                if(_isNextComboAttack)
                {
                    _isNextComboAttack = false;
                    ++_comboStep;
                }
            }
        }
    }

    public void ComboPossible()
    {
        _isNextComboAttack = true;
    }

    private void ComboAttack()
    {

        if (_comboStep == 2)
            _playerAnimator.Play("Attack2");
        if (_comboStep == 3)
            _playerAnimator.Play("Attack3");
    }

    private void ComboReset()
    {
        _isNextComboAttack = false;
        _comboStep = 0;
        _playerMove.ResetMove();
    }


}