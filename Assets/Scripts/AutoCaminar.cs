using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCaminar : MonoBehaviour {

    public GameObject VisionVR;
    public const int Angulo = 90;
    public bool EstaCaminando = false;
    public float Velocidad;
    public bool CaminarPulsar;
    public bool CaminarMirar;
    public double AnguloUmbral;
    public bool CongelarposicionY;
    public float CompensarY;

	
	// Update is called once per frame
	void Update () {
		if(CaminarMirar && !CaminarPulsar && !EstaCaminando && VisionVR.transform.eulerAngles.x >= 
            AnguloUmbral && VisionVR.transform.eulerAngles.x <= Angulo)
        {
            EstaCaminando = true;
        }else if (CaminarMirar && !CaminarPulsar && EstaCaminando && (VisionVR.transform.eulerAngles.x <=
            AnguloUmbral || VisionVR.transform.eulerAngles.x >= Angulo)){
            EstaCaminando = false;
        }
        if (EstaCaminando)
        {
            Caminar();
        }
        if (CongelarposicionY)
        {
            transform.position = new Vector3(transform.position.x, CompensarY, transform.position.z);
        }
    }

    public void Caminar()
    {
        Vector3 Direccion = new Vector3(VisionVR.transform.forward.x , 0, VisionVR.transform.forward.z).normalized * Velocidad * Time.deltaTime;
        Quaternion Rotacion = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y , 0));
        transform.Translate(Rotacion * Direccion);
    }


}

