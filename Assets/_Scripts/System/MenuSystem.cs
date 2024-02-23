using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    private enum Type { UD_Only, LR_Only, UD_Allow, LR_Allow }
    [SerializeField] private Type type;
    [SerializeField] private int AllowDistance;
    [SerializeField] private List<Vector3> SelectOptions;
    [SerializeField] Transform Marker;

    [ContextMenu("Add Transform")]
    public void AddTransform()
    {
        if (Marker == null) { print("Marker is Empty"); return; }
        if (SelectOptions == null) { SelectOptions = new List<Vector3>(); }
        SelectOptions.Add(Marker.transform.localPosition);
    }
}
