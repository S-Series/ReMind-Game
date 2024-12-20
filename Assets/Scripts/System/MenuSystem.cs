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
    [SerializeField]
    private int maxIndex, colCount;
    private InputAction[] actions = new InputAction[5];
    private Animator frameAnimation = null;
    private Button[][] ItemAction;
    private Button SelectItemUpdateAction;

    [SerializeField] private bool isOverflowToNextSection = true;
    [SerializeField] int[] rowCounts;
    [SerializeField] Button[] _ActionItems;
    [SerializeField] Transform frame;
    [SerializeField] Vector2 frameRetouchVec2;

    private void Start()
    {
        int itemCount = 0;
        maxIndex = _ActionItems.Length - 1;

        foreach(int ints in rowCounts) { itemCount += ints; }
        if (_ActionItems.Length != itemCount) { throw new SystemException(""); }

        List<Button> list = new List<Button>();
        List<Button[]> returnList = new List<Button[]>();
        TryGetComponent<Animator>(out var animator);
        if (animator != null) { frameAnimation = animator; }

        int rowIndex = 0;
        for (int i = 0; i < maxIndex + 1; i++)
        {
            list.Add(_ActionItems[i]);
            if (list.Count == rowCounts[rowIndex])
            {
                returnList.Add(item: list.ToArray());
                list = new List<Button>();
                rowIndex++;
            }
        }
        ItemAction = returnList.ToArray();

        #region #Actions Initialize
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
        #endregion
    }
    private void OptionSelect()
    {
        Button targetButton;
        targetButton = ItemAction[itemIndex[1]][itemIndex[0]];
        if (targetButton.interactable)
        {
            try {targetButton.onClick.Invoke();}
            catch { throw new Exception("Invoke Action Enable"); }
            frameAnimation?.SetTrigger(AnimationTrigger);
        }
        else
        {
            
        }
    }
    private void OptionMovement_UD(bool isPositive)
    {
        if (isPositive)
        {
            itemIndex[1]++;
            if (itemIndex[1] > ItemAction.Length - 1)
            {
                itemIndex[1] -= ItemAction.Length;
            }
            if (itemIndex[0] > ItemAction[itemIndex[1]].Length - 1)
            {
                itemIndex[0] = ItemAction[itemIndex[1]].Length - 1;
            }
        }
        else
        {
            itemIndex[1]--;
            if (itemIndex[1] < 0)
            {
                itemIndex[1] += ItemAction.Length;
            }
            if (itemIndex[0] > ItemAction[itemIndex[1]].Length - 1)
            {
                itemIndex[0] = ItemAction[itemIndex[1]].Length - 1;
            }
        }
        UpdateFrame();
    }
    private void OptionMovement_LR(bool isPositive)
    {
        if (isPositive)
        {
            itemIndex[0]++;
            if (itemIndex[0] > rowCounts[itemIndex[1]] - 1)
            {
                itemIndex[0] -= rowCounts[itemIndex[1]];
                if (isOverflowToNextSection)
                {
                    itemIndex[1]++;
                    if (itemIndex[1] > rowCounts.Length - 1)
                    {
                        itemIndex[1] -= rowCounts.Length;
                    }
                }
            }
        }
        else
        {
            itemIndex[0]--;
            if (itemIndex[0] < 0)
            {
                if (isOverflowToNextSection)
                {
                    itemIndex[1]--;
                    if (itemIndex[1] < 0) { itemIndex[1] += ItemAction.Length; }
                    if (itemIndex[0] > rowCounts[itemIndex[1]] - 1)
                    {
                        itemIndex[0] = rowCounts[itemIndex[1]] - 1;
                    }
                }
                itemIndex[0] += rowCounts[itemIndex[1]];
            }
        }
        ItemUpdate();
        UpdateFrame();
    }
    private void UpdateFrame()
    {
        Vector3 vec3;
        vec3 = ItemAction[itemIndex[1]][itemIndex[0]].transform.position;
        frame.transform.position = new Vector3(
            vec3.x - frameRetouchVec2.x,
            vec3.y - frameRetouchVec2.y,
            vec3.z
        );
    }
    private void ItemUpdate()
    {
        try { SelectItemUpdateAction.onClick.Invoke(); }
        catch { throw new Exception("Invoke Action Enable"); }
    }
}
