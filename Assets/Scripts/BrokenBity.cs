using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBity : Task
{
    [SerializeField] private List<GameObject> bodyParts;
    private int foundParts = 0;
    
    public override void DoTask(GameObject character, Action onTaskFinished)
    {
        if(foundParts == bodyParts.Count)
        {
            onTaskFinished.Invoke();
        } else
        {
            foundParts++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
