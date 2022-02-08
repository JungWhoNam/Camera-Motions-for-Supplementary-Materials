using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMotions
{
    public class PanMotion : MonoBehaviour
    {
        public Camera movingCamera;
        public Transform from;
        public Transform to;

        [Range(0.0f, 1.0f)]
        public float progress;
        [Range(0.0f, 1.0f)]
        public float incAmtPerSes = 0.1f;
        public bool loop = false;

        private void Update()
        {
            progress += incAmtPerSes * Time.deltaTime;
            if (loop) progress = progress > 1f ? 0 : progress;
            else progress = Mathf.Clamp01(progress);

            UpdateCamera(progress);
        }

        private void UpdateCamera(float progress)
        {
            (movingCamera == null ? Camera.main : movingCamera).
                transform.SetPositionAndRotation(
                    Vector3.Lerp(from.position, to.position, progress),
                    Quaternion.Lerp(from.rotation, to.rotation, progress)
                );
        }
    }

}