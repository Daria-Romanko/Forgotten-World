using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform dest;
    [SerializeField]
    public CinemachineVirtualCamera camera1;
    [SerializeField]
    public CinemachineVirtualCamera camera2;

    public Transform GetTransform() { return dest; }
}