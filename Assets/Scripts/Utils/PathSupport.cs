using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class PathSupport : MonoBehaviour
{
    [SerializeField] private PathCreator p1;
    [SerializeField] private PathCreator p2;
    void Start()
    {
        p1.bezierPath.Space = PathSpace.xyz;
        p2.bezierPath.Space = PathSpace.xyz;
    }
    
}
