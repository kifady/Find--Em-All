using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to set the instructions text UI text to a string defined in the editor.
/// </summary>

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
