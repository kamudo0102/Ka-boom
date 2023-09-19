using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    CinemachineVirtualCamera vcam;

    public void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();

        vcam.Follow = GameObject.FindWithTag("Player").transform;


    }
}
