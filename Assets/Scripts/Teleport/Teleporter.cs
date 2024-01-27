using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform dest;

    public Transform GetTransform() { return dest; }
}
