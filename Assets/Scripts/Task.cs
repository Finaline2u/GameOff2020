using System;
using UnityEngine;

public abstract class Task: MonoBehaviour
{
    public static event EventHandler OnTaskClicked;

    private Transform taskPosition;
    /*public Task (Transform taskTransform)
    {
        taskPosition = taskTransform;
    }*/

    private void OnMouseDown()
    {
        OnTaskClicked?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetTaskPosition()
    {
        return transform.position;
    }
}
