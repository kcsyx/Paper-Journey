using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScene : MonoBehaviour
{

    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("Title Screen");
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Title Screen");
    }
}

