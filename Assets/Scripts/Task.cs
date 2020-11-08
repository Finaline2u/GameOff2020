using System;
using UnityEngine;

public abstract class Task: MonoBehaviour
{
    public static event EventHandler OnTaskClicked;
    protected bool isCooldown = false;

    public bool IsCooldown { get => isCooldown; }

    private void OnMouseDown()
    {
        OnTaskClicked?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetTaskPosition()
    {
        return transform.position;
    }

    public abstract void DoTask(GameObject character, Action onTaskFinished);
}
