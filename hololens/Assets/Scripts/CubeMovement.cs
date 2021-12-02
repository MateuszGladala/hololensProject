using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


    public class CubeMovement : MonoBehaviour, IFocusable, IInputClickHandler
    {
        
    public float RotationSpeed;
    void Update()
    {
        if (Rotating)
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        unRotate();
        
    }

    void unRotate()
    {
        if (gameObject.GetComponent<Rigidbody>().useGravity == true)
        {
            Rotating = false;
        }
    }

        public bool Rotating;
        public void OnFocusEnter()
        {
            Rotating = true;
        }
        public void OnFocusExit()
        {
            Rotating = false;
        }
        public Vector3 ScaleChange;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            moveCube();
        }

        void moveCube()
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

