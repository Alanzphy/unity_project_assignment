using UnityEngine;

public class SensorManager : MonoBehaviour

{

    public GameObject lodo;
    public void SetupSensors(SensorInfo sensorInfo)
    {
        if (sensorInfo.humedad > 0.5f)
        {
            lodo.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            lodo.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        Debug.Log("Sensores: " + sensorInfo.sensores.Count);
    }
}
