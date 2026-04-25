using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CustomRequest : MonoBehaviour
{
    public string url;
    public SensorManager sensorManager;

    [HideInInspector]
    public UIManager uiManager;

    private bool _requestInProgress = false;

    void Start()
    {
        // Petición automática al iniciar
        HacerRequest();
    }

    /// <summary>
    /// Lanza una petición HTTP al servidor.
    /// Puede llamarse desde un botón de la UI.
    /// </summary>
    public void HacerRequest()
    {
        if (_requestInProgress)
        {
            Debug.Log("[CustomRequest] Petición ya en curso, espera un momento.");
            return;
        }
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        _requestInProgress = true;

        // Informar al usuario que se está cargando
        if (uiManager != null)
            uiManager.MostrarEstado(">> Cargando datos...");

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    string errorConexion = pages[page] + ": Error: " + webRequest.error;
                    Debug.LogError(errorConexion);
                    if (uiManager != null)
                        uiManager.MostrarEstado("ERROR de conexion: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.ProtocolError:
                    string errorHttp = pages[page] + ": HTTP Error: " + webRequest.error;
                    Debug.LogError(errorHttp);
                    if (uiManager != null)
                        uiManager.MostrarEstado("ERROR HTTP: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.Success:
                    string jsonString = webRequest.downloadHandler.text;
                    SensorInfo sensorInfo = JsonUtility.FromJson<SensorInfo>(jsonString);

                    // Actualizar la escena 3D (lógica original)
                    if (sensorManager != null)
                        sensorManager.SetupSensors(sensorInfo);

                    // Actualizar la UI con los nuevos datos
                    if (uiManager != null)
                        uiManager.ActualizarUI(sensorInfo);

                    Debug.Log("[CustomRequest] Datos recibidos correctamente.");
                    break;
            }
        }

        _requestInProgress = false;
    }
}
