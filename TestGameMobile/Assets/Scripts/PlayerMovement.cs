using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _maxOffsetx;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotSpeed;

    private float _touchXNorm;
    private Vector3 _pos;
    private bool _isTouching;
    private Vector3 _rot;
    private Vector3 _targetRot;

    private void Update()
    {
        //First touch
        if (Input.GetMouseButtonDown(0) && !_isTouching)
        {
            _isTouching = true;
            Vector2 mPos = Input.mousePosition;
            _touchXNorm = mPos.x / Screen.width;
        }

        //Drag
        if (Input.GetMouseButton(0) && _isTouching)
        {
            Vector2 mPos = Input.mousePosition;
            float xNorm = mPos.x / Screen.width;
            float deltax = xNorm - 0.5f;
            _pos.x += deltax * _moveSpeed * Time.deltaTime;

            _pos.x = Mathf.Clamp(_pos.x, -_maxOffsetx, _maxOffsetx);

            transform.localPosition = _pos;
            if (Mathf.Abs (deltax) < 0.01f)
            {
                deltax = 0f;
            }
            _targetRot.y = MathF.Sign(deltax) * 45;
            
            
        }

        if (!Input.GetMouseButton(0) && _isTouching)
        {
            _targetRot.y = 0;
            _isTouching = false;
        }

        _rot = Vector3.MoveTowards(_rot, _targetRot, _rotSpeed * Time.deltaTime);
        transform.localEulerAngles = _rot;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
