using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShip : MonoBehaviour, ITaskObject
{
    private float shipFixPercentage = 0;
    private bool hasChangeFix = false;

    public float ShipFixPercentage { get => shipFixPercentage; set => shipFixPercentage = value; }
    public bool HasChangeFix { get => hasChangeFix; set => hasChangeFix = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void risePercentage()
    {
        shipFixPercentage++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTask(CharacterStats characterStats)
    {
        HasChangeFix = true;
        float fixEfficience = 1 + (characterStats.Intelligence / 10);
        shipFixPercentage += 1 * fixEfficience;
        Debug.Log("Consertando Nave...");
        GetComponent<Timer>().AwaitForSeconds(2, () => {
            Debug.Log("Nave Reparada.");
            HasChangeFix = false;
        });
    }

    public void OnTaskFinished()
    {
        throw new System.NotImplementedException();
    }
}
