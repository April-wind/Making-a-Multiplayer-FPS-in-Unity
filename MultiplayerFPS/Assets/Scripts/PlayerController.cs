using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	[SerializeField] private float speed = 5f;
	[SerializeField] private float lookSensitivity = 3f;
	private PlayerMotor _playerMotor;

	private void Start()
	{
		_playerMotor = this.GetComponent<PlayerMotor>();
	}

	private void Update()
	{
		//Calculate movement velocity as a 3D vector
		float _xMove = Input.GetAxisRaw("Horizontal");
		float _zMove = Input.GetAxisRaw("Vertical");


		Vector3 _moveHorizontal = transform.right * _xMove;
		Vector3 _moveVertical = transform.forward * _zMove;
		
		//final movement vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

		//Apply movement
		_playerMotor.Move(_velocity);
		
		//Calculate rotation velocity as a 3D vector(turning around)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;
		
		//Apply rotation
		_playerMotor.Rotate(_rotation);
		
		//Calculate camera rotation velocity as a 3D vector(turning around)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _camerarotation = new Vector3(_xRot, 0, 0) * lookSensitivity;
		
		//Apply camera rotation
		_playerMotor.RotateCamera(_camerarotation);
	}
}
