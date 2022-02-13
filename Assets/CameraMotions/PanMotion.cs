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
        public float incAmtPerSec = 0.1f;
        public bool loop = false;
        public bool backward = false;

        private void Update()
        {
            progress += (backward ? -1 * incAmtPerSec : incAmtPerSec) * Time.deltaTime;

            if (loop && backward) progress = progress < 0f ? 1f : progress;
            else if (loop && !backward) progress = progress > 1f ? 0 : progress;
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