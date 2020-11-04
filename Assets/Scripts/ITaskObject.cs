using UnityEngine;

public interface ITaskObject
{
    void DoTask(CharacterStats characterStats);
    void OnTaskFinished();
}