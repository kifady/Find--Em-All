using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public Text instruction;
    public string instructionText;

    internal void ActivateText()
        {
        instruction.text = instructionText;
        }
    internal void SetAndActivateText(string newText)
        {
        instruction.text = newText;
        }

    internal void DeactivateText()
        {
        instruction.text = "";
        }
    }
