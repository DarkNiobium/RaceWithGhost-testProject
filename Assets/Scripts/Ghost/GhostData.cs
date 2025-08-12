using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostData
{
    public List<Vector3> Positions;
    public List<Quaternion> Rotations;

    //Обьект для удобного хранения позиции и поворота :)
    public GhostData(List<Vector3> positions, List<Quaternion> rotations)
    {
        Positions = new List<Vector3>(positions);
        Rotations = new List<Quaternion>(rotations);
    }
}
