using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Shapes))]
public class ShapesEditor : Editor
{
    private Shapes _shapes;
    
    void OnEnable()
    {
        _shapes = target as Shapes;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Find possible neighbors"))
        {
            Debug.Log(_shapes.possibleShapes.Count);
            ((Shapes)target).PossibleNeighborsW= WaveFunctionCollapse.ReturnMatchingShapes(_shapes, direction.West, _shapes.possibleShapes);
            ((Shapes)target).PossibleNeighborsN= WaveFunctionCollapse.ReturnMatchingShapes(_shapes, direction.North, _shapes.possibleShapes);
            ((Shapes)target).PossibleNeighborsE= WaveFunctionCollapse.ReturnMatchingShapes(_shapes, direction.East, _shapes.possibleShapes);
            ((Shapes)target).PossibleNeighborsS= WaveFunctionCollapse.ReturnMatchingShapes(_shapes, direction.South, _shapes.possibleShapes);
            
            EditorUtility.SetDirty(_shapes);
        }
    }
}
