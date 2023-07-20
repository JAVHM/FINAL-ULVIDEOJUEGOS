using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaSO", menuName = "ScriptableObject/Area")]
public class AreaSO : ScriptableObject
{
    public bool hasFog;
    public Color fogColor;
    public Color superiorColor;
    public Color inferiorColor;
}
