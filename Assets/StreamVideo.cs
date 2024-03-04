using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public struct Data
{
    public string Name;
    public string VideoURL;
}

public class StreamVideo : MonoBehaviour
{
    [SerializeField] Text uiNameText;
    [SerializeField] RawImage uiRawImage;
    string jsonURL = "https://drive.google.com/uc?export=download&id=1W5aw7-MBuu128VMULKA9XfgqLtl9j3uJ";

    void Start()
    {
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            // error ...

        }
        else
        {
            // success...
            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);


            // Load image:
            StartCoroutine(GetImage(data.VideoURL));
        }

        // Clean up any resources it is using.
        request.Dispose();
    }

    IEnumerator GetImage(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            // error ...

        }
     else {
         //success...
         uiRawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture ;
      }


// Clean up any resources it is using.
request.Dispose();
    }
}
