using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMinimap : MonoBehaviour
{
    public Transform player;
    public Transform moto;
    public static bool conduciendo = false;
    public Camera cam;

    private void Update()
    {
        zoomCamera();
    }

    private void LateUpdate()
    {
        Vector3 newPosicion;
        if (conduciendo)
        {
            newPosicion = moto.position;
        }
        else
        {
            newPosicion = player.position;
        }
        newPosicion.y = transform.position.y;
        transform.position = newPosicion;
    }

    private void zoomCamera()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            cam.orthographicSize += 5;
        }else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            cam.orthographicSize -= 5;
        }
    }
}
