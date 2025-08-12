using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    private List<Vector3> positions = new();
    private List<Quaternion> rotations = new();

    public bool IsRecording { get; private set; }

    public void StartRecording()
    {
        positions.Clear();
        rotations.Clear();
        IsRecording = true;
    }

    public void StopRecording()
    {
        IsRecording = false;
    }

    public GhostData GetData()
    {
        return new GhostData(positions, rotations);
    }

    //Fixed Update а не просто Update,небольшая но оптимизиация
    private void FixedUpdate()
    {
        if (!IsRecording) return;

        positions.Add(transform.position);
        rotations.Add(transform.rotation);
    }
}
