using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMotions
{
    public class RotateMotion : MonoBehaviour
    {
        public Camera movingCamera;
        public Transform rotateAround;

        [Range(0.0f, 180.0f)]
        public float incAmtPerSes = 36f;

        private void Update()
        {
            UpdateCamera(incAmtPerSes * Time.deltaTime);
        }

        private void UpdateCamera(float intAmt)
        {
            (movingCamera == null ? Camera.main : movingCamera).
                transform.RotateAround(
                    rotateAround.transform.position,
                    rotateAround.transform.up,
                    intAmt
                );
        }
    }
}
