using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]


public class ContoladorVRPlayer : MonoBehaviour {

    private CharacterController ControladorPersona;
    private Vector3 MovimientoDireccion = Vector3.zero;
    private Vector2 Entrada;

    private CollisionFlags BanderasDeCollision;

    public float FuerzaTocarSuelo;
    public float MultiplicarGravedad;

    // Use this for initialization
    void Start() {
        ControladorPersona = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate() {

        Vector3 MovimientoDeseado = transform.forward * Entrada.y + transform.right * Entrada.x;

        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, ControladorPersona.radius, Vector3.down, out hitInfo, 
            ControladorPersona.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        MovimientoDeseado = Vector3.ProjectOnPlane(MovimientoDeseado,hitInfo.normal).normalized;

        if (ControladorPersona.isGrounded)
        {
            MovimientoDireccion.y = -FuerzaTocarSuelo;
        }
        else
        {
            MovimientoDireccion += Physics.gravity * MultiplicarGravedad * Time.fixedDeltaTime;
        }

        BanderasDeCollision = ControladorPersona.Move(MovimientoDireccion * Time.fixedDeltaTime);
    }
}


