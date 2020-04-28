using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour
{

    public GameObject VRCamara;

    private float PosicionInicialY = 0f;
    private float PosicionDelGyroY = 0f;
    private float CalibracionPosicionY = 0f;

    public bool InicioJuego;

    // Use this for initialization
    void Start()
    {
        Input.gyro.enabled = true;
        PosicionInicialY = VRCamara.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        AplicarRotacionGiroscopio();
        AplicarCalibracion();

        if (InicioJuego == true)
        {
            Invoke("CalibrarPosicionY", 3f);
            InicioJuego = false;
        }
    }

    void AplicarRotacionGiroscopio()
    {
        VRCamara.transform.rotation = Input.gyro.attitude;
        VRCamara.transform.Rotate(0f, 0f, 180f, Space.Self);
        VRCamara.transform.Rotate(90f, 180f, 0f, Space.World);
        PosicionDelGyroY = PosicionInicialY = VRCamara.transform.eulerAngles.y;
    }

    void CalibrarPosicionY()
    {

        CalibracionPosicionY = PosicionDelGyroY - PosicionInicialY;

    }

    void AplicarCalibracion()
    {
        VRCamara.transform.Rotate(0f, -CalibracionPosicionY, 0f, Space.World);
    }
}
