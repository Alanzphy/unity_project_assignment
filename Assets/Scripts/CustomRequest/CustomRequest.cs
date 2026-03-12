using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class CustomRequest : MonoBehaviour
{
    public string url;
    
    void Start()
    {
        // A non-existing page.
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string jsonString = webRequest.downloadHandler.text;
                    //PokeInfo pokeInfo = JsonUtility.FromJson<PokeInfo>(jsonString);
                    //Debug.Log("Count: + " + pokeInfo.count);
                    SensorInfo sensorInfo = JsonUtility.FromJson<SensorInfo>(jsonString);
                    Debug.Log("Count: + " + sensorInfo.sensores.Count);
                    break;
            }
        }
    }
}
