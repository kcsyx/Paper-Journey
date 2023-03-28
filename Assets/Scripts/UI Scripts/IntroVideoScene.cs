using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroVideoScene : MonoBehaviour
{

    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;

        AudioManager.instance.StopBGM();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)) {
            SceneManager.LoadScene("Level 1");
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Level 1");
    }
}

