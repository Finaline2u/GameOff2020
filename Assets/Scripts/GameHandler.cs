using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    [SerializeField] private Transform shipNodeTransform;
    [SerializeField] private Transform scavengerNodeTransform;

    private void Awake()
    {
        instance = this;
    }

    private Transform GetResourceNode()
    {
        return shipNodeTransform;
    }

    public static Transform GetResourceNode_Static()
    {
        return instance.GetResourceNode();
    }
}
