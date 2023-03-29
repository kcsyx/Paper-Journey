using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public new Camera camera;

    private float initialZoom = 8.379144f;
    private float newZoom = 20f;
    private float time = 0.6f;

    void Start()
    {
        if (Camera.main != null)
        {
            camera = Camera.main;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && camera.orthographicSize == initialZoom)
        {
            StartCoroutine(resizeRoutine(initialZoom, newZoom, time));
        }
    }

    private IEnumerator resizeRoutine(float initialZoom, float newZoom, float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            camera.orthographicSize = Mathf.Lerp(initialZoom, newZoom, t);
            yield return null;
        }
    }

}
