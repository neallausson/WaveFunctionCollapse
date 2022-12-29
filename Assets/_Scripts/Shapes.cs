using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction {West=0,North=1,East=2,South=3}

public class Shapes : MonoBehaviour
{
    [SerializeField] public List<Shapes> possibleShapes;
    //0 = plane, 1 = cube
    [SerializeField] public int[] objectShape = new int[] {0,0,0,0};

    [SerializeField] public List<Shapes> PossibleNeighborsW;
    [SerializeField] public List<Shapes> PossibleNeighborsN;
    [SerializeField] public List<Shapes> PossibleNeighborsE;
    [SerializeField] public List<Shapes> PossibleNeighborsS;

}
