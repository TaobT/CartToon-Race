using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    [SerializeField] private int checkpointId;
    public int CheckpointId => checkpointId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaceController.instance.CheckpointReached(checkpointId);
        }
    }

    private void OnDrawGizmos()
    {
        if (RaceController.instance == null)
        {
            return;
        }

        // Determinar el color con una comparación más directa
        Gizmos.color = (checkpointId == RaceController.instance.NextCheckpoint) ? Color.green : Color.blue;

        // Optimizar la transformación para dibujar solo una vez
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}

