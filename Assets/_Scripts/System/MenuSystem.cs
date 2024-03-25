using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Linq;

public class MenuSystem : MonoBehaviour
{
    private const string AnimationTrigger = "Play";

    public int[] itemIndex = new int[2] { 0, 0 }; //$ { row, col }
    private int maxIndex, colCount;
    private InputAction[] actions = new InputAction[5];
    private Animator frameAnimation;
    private Button[][] ActionItems;

    [SerializeField] private int rowCount;
    [SerializeField] private bool isOverflowToNextSection = true;
    [SerializeField] Button[] _ActionItems;
    [SerializeField] Transform frame;

    private void Start()
    {
        if (rowCount < 0) { rowCount = 1; }
        maxIndex = _ActionItems.Length - 1;
        colCount = Mathf.CeilToInt((maxIndex + 1.0f) / rowCount);

        //# private Button[][] ActionItems;
        List<Button> list = new List<Button>();
        List<Button[]> returnList = new List<Button[]>();
        for (int i = 0; i < maxIndex + 1; i++)
        {
            list.Add(_ActionItems[i]);
            if (list.Count == rowCount)
            {
                returnList.Add(item: list.ToArray());
                list = new List<Button>();
            }
            _ActionItems[i].GetComponent<MenuItem>().
                itemIndex = new int[2] { i / rowCount, i % rowCount };
        }
        ActionItems = returnList.ToArray();

        actions = new InputAction[5]{
            new InputAction(),
            new InputAction(),
            new InputAction(),
            new InputAction(),
            new InputAction()
        };

        actions[0].performed += item => OptionSelect();
        actions[0].AddBinding("<Keyboard>/Enter");
        actions[0].Enable();

        actions[1].performed += item => OptionMovement_UD(false);
        actions[1].AddBinding("<Keyboard>/UpArrow");
        actions[1].Enable();

        actions[2].performed += item => OptionMovement_UD(true);
        actions[2].AddBinding("<Keyboard>/DownArrow");
        actions[2].Enable();

        actions[3].performed += item => OptionMovement_LR(false);
        actions[3].AddBinding("<Keyboard>/LeftArrow");
        actions[3].Enable();

        actions[4].performed += item => OptionMovement_LR(true);
        actions[4].AddBinding("<Keyboard>/RightArrow");
        actions[4].Enable();
    }
    private void OptionSelect()
    {

    }
    private void OptionMovement_UD(bool isPositive)
    {
        if (isPositive)
        {
            itemIndex[1]++;
            if (itemIndex[1] > ActionItems.Length - 1)
            {
                itemIndex[1] -= ActionItems.Length;
            }
        }
        else
        {
            itemIndex[1]--;
            if (itemIndex[1] < 0)
            {
                itemIndex[1] += ActionItems.Length;
                if (itemIndex[0] > ActionItems[itemIndex[1]].Length - 1)
                {
                    itemIndex[0] = ActionItems[itemIndex[1]].Length;
                }
            }
        }
    }
    private void OptionMovement_LR(bool isPositive)
    {
        itemIndex[0] += isPositive ? 1 : -1;
        if (isPositive)
        {
            itemIndex[0]++;
            if (itemIndex[0] > ActionItems[itemIndex[1]].Length - 1)
            {
                itemIndex[0] -= ActionItems[itemIndex[1]].Length;
                if (isOverflowToNextSection)
                {
                    itemIndex[1]++;
                    if (itemIndex[1] > ActionItems.Length - 1)
                    {
                        itemIndex[1] -= ActionItems.Length;
                    }
                }
            }
        }
        else
        {
            itemIndex[0]--;
            if (itemIndex[0] < 0)
            {
                itemIndex[0] += ActionItems[itemIndex[1]].Length;
                if (isOverflowToNextSection)
                {
                    itemIndex[1]--;
                    itemIndex[1] += ActionItems.Length;
                    if (itemIndex[0] > ActionItems[itemIndex[1]].Length - 1)
                    {
                        itemIndex[0] = ActionItems[itemIndex[1]].Length;
                    }
                }
            }
        }
    }
    public void testAction(int i)
    {
        print(i);
    }
}
