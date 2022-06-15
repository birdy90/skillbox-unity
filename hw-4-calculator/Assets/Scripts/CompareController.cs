using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompareController : MonoBehaviour
{
    [SerializeField] private string resultPlaceholder = "...";
    [SerializeField] private TMP_Text resultField;
    [SerializeField] private TMP_InputField a;
    [SerializeField] private TMP_InputField b;

    void Start()
    {
        resultField.text = resultPlaceholder;
    }
    
    private void ShowError()
    {
        resultField.text = "X";
        resultField.color = Color.red;   
    }

    private void ShowResult(string result)
    {
        resultField.text = result;
        resultField.color = Color.white;   
    }

    public void CompareOperation()
    {
        if (!float.TryParse(a.text, out var aValue))
        {
            ShowError();
            return;
        }

        if (!float.TryParse(b.text, out var bValue))
        {
            ShowError();
            return;
        }

        if (Math.Abs(aValue - bValue) < Single.Epsilon)
        {
            ShowResult("=");
        } 
        else
        {
            ShowResult(aValue < bValue ? "<" : ">");
        }
    }
}
 