using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuSystem : MonoBehaviour
{
    public int itemIndex;
    [SerializeField]
    private int maxIndex, colCount;
    [SerializeField] private int rowCount;
    [SerializeField] Button[] ActionItems;
    [SerializeField] MenuItem[] ActionTriggers;
    [SerializeField] InputAction[] actions = new InputAction[5];
    [SerializeField] Transform frame;

    private void Start()
    {
        if (rowCount < 0) { rowCount = 1; }
        maxIndex = ActionItems.Length - 1;
        colCount = Mathf.CeilToInt((maxIndex + 1.0f) / rowCount);
        ActionTriggers = new MenuItem[maxIndex + 1];
        for (int i = 0; i < maxIndex + 1; i++)
        {
            ActionTriggers[i] = ActionItems[i].GetComponent<MenuItem>();
        }

        actions[0].performed += item => OptionSelect();
        actions[0].AddBinding("<Keyboard>/Enter");
        actions[0].Enable();

        actions[1].performed += item => OptionMovement(1);
        actions[1].AddBinding("<Keyboard>/UpArrow");
        actions[1].Enable();

        actions[2].performed += item => OptionMovement(2);
        actions[2].AddBinding("<Keyboard>/DownArrow");
        actions[2].Enable();

        actions[3].performed += item => OptionMovement(3);
        actions[3].AddBinding("<Keyboard>/LeftArrow");
        actions[3].Enable();

        actions[4].performed += item => OptionMovement(4);
        actions[4].AddBinding("<Keyboard>/RightArrow");
        actions[4].Enable();
    }
    private void OptionSelect()
    {
        ActionItems[itemIndex].onClick?.Invoke();
    }
    private void OptionMovement(int value)
    {
        switch (value)
        {
            //$ Up
            case 1:
                itemIndex -= rowCount;
                if (itemIndex < 0) { itemIndex = Mathf.Min(maxIndex, itemIndex + colCount * rowCount); }
                break;
            
            //$ Down
            case 2:
                itemIndex += rowCount;
                if (itemIndex >= colCount * rowCount) { itemIndex -= colCount * rowCount; }
                else if (itemIndex > maxIndex) { itemIndex = maxIndex;}
                break;
            
            //$ Left
            case 3:
                itemIndex -= 1;
                if (itemIndex < 0) { itemIndex += maxIndex + 1; }
                break;
            
            //$ Right
            case 4:
                itemIndex += 1;
                if (itemIndex > maxIndex) { itemIndex -= maxIndex + 1; }
                break;
        }
        frame.localPosition = ActionItems[itemIndex].transform.localPosition;
    }
    public void testAction(int i)
    {
        print(i);
    }
}
