using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*    public Transform target;
        public Vector3 offset;

        [Range(1, 10)]
        public float smoothFactor;
        public Vector3 minValues, maxValue;

        private void FixedUpdate()
        {
            Follow();
        }


        void Follow()
        {
            Vector3 targetPosition = target.position + offset;

            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
                Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
                Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));

            Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }*/

    public Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0f, 1f)]
    public float smoothTime;

    public Vector3 positionOffset;

    public Vector2 xLimit;
    public Vector2 yLimit;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
