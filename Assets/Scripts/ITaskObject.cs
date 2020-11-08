using System;
using UnityEngine;

public interface ITaskObject
{
    void DoTask(CharacterStats characterStats, Action onTaskFinished);
}