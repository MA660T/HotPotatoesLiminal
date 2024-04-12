using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyStage
{
    public ShapeBase[] mainShapes;
    public ShapeBase bonusShape;

    public int bonusScore;
}
