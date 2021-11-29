using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;



    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (player.position.y != transform.position.y && player.position.y > -4 && player.position.x < 12f)//akan berhenti mengikuti jika kurang dari pemain jatuh
        {
            Vector3 playerPosistion = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosistion, smoothFactor * Time.deltaTime);
            transform.position = playerPosistion;
        }
    }
}
