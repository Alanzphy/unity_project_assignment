using UnityEngine;

public class SensorManager : MonoBehaviour

{

    public GameObject[] lodos;

    void Awake()
    {
        if (lodos == null || lodos.Length == 0)
        {
            lodos = GameObject.FindGameObjectsWithTag("Lodo");
        }
    }


    public void SetupSensors(SensorInfo sensorInfo)
    {
        Color darkBrown = new Color(0.35f, 0.20f, 0.10f);
        Color lightBrown = new Color(0.75f, 0.60f, 0.40f);
        Color newColor = sensorInfo.humedad > 0.5f ? darkBrown : lightBrown;

        foreach (GameObject lodo in lodos)
        {
            if (lodo != null)
            {
                lodo.GetComponent<MeshRenderer>().material.color = newColor;
            }
        }

        Debug.Log("Sensores: " + sensorInfo.sensores.Count);
    }
}
