using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;


public class StreamVideo : MonoBehaviour
{
    [SerializeField] string videoFilename;
    [SerializeField] VideoPlayer videoPlayer;

    void Start()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFilename);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }

    
}
