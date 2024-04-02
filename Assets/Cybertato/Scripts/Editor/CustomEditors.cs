using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawner))]
public class SpawnShapeEditor : Editor
{
    private Spawner spawner;
    private int shapeIndex;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        spawner = (Spawner)target;
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Chose Shape To Spawn", EditorStyles.boldLabel);

        // Display a dropdown list to choose a shape
        shapeIndex = EditorGUILayout.Popup("Shape", shapeIndex, GetShapeOptions());

        // Apply the selected shape when the user clicks a button
        if (GUILayout.Button("Spawn Shape"))
        {
            spawner.SpawnGivenObject(shapeIndex);
        }
    }
    
    private string[] GetShapeOptions()
    {
        string[] shapeOptions = new string[spawner.shapes.Length];
        for (int i = 0; i < spawner.shapes.Length; i++)
        {
            shapeOptions[i] = spawner.shapes[i].myShape.ToString();
        }
        return shapeOptions;
    }
}
