using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CustomRequest : MonoBehaviour
{
    public string url;
    public SensorManager sensorManager;
    
    void Start()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        while (true)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
        
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
                        string jsonString = webRequest.downloadHandler.text;
                        SensorInfo sensorInfo = JsonUtility.FromJson<SensorInfo>(jsonString);
                        sensorManager.SetupSensors(sensorInfo);
                        break;
                }
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
