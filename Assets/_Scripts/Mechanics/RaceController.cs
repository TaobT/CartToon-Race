using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public enum RaceState
    {
        NotStarted,
        Racing,
        Finished
    }

    public static RaceController instance;
    [SerializeField] private int totalCheckpoints;

    //Para un solo jugador (por ahora)
    private int nextCheckpoint = 0;

    public int NextCheckpoint => nextCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void CheckpointReached(int checkpointId)
    {
        if(checkpointId == nextCheckpoint)
        {
            nextCheckpoint++;
            if(nextCheckpoint >= totalCheckpoints)
            {
                nextCheckpoint = 0;
                Debug.Log("Vuelta Completada");
            }
        }
    }
}
