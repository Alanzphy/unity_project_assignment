using System;
using System.Collections.Generic;

[System.Serializable]
public class SensorInfo
{
    public float temperatura;
    public float humedad;

    public List<Sensor> sensores;

}

[System.Serializable]

public class Sensor
{
    public string nombre;
}
