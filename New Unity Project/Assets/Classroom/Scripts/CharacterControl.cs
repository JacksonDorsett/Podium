using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeutronCat.Classroom
{
    public class CharacterControl : MonoBehaviour
    {

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private CharacterController _characterController;
        private Camera _camera;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;

            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            _characterController.SimpleMove(moveDir * _moveSpeed);

            float yRot = Input.GetAxis("Mouse X") * _rotateSpeed;
            float xRot = Input.GetAxis("Mouse Y") * _rotateSpeed;
            transform.Rotate(0, yRot, 0);
            _camera.transform.Rotate(-xRot, 0, 0);

            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}