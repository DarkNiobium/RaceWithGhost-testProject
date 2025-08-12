using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    private GhostData ghostData;
    private int index;
    private bool isPlaying;

    public void Play(GhostData data)
    {
        ghostData = data;
        index = 0;
        isPlaying = ghostData.Positions.Count > 0;

        if (isPlaying)
        {
            transform.position = ghostData.Positions[0];
            transform.rotation = ghostData.Rotations[0];
        }
    }

    private void FixedUpdate()
    {
        if (!isPlaying || index >= ghostData.Positions.Count) return;

        transform.position = ghostData.Positions[index];
        transform.rotation = ghostData.Rotations[index];

        index++;
        if (index >= ghostData.Positions.Count)
            isPlaying = false;
    }
}
