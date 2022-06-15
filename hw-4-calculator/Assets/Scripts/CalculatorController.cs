using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorController : MonoBehaviour
{
    [SerializeField] private string resultPlaceholder = "...";
    [SerializeField] private TMP_Text resultField;
    [SerializeField] private TMP_InputField a;
    [SerializeField] private TMP_InputField b;
    
    private const string Plus = "+";
    private const string Minus = "-";
    private const string Multiply = "*";
    private const string Divide = "/";
    
    void Start()
    {
        resultField.text = resultPlaceholder;
    }

    private void ShowError(string error)
    {
        resultField.text = error;
        resultField.color = Color.red;   
    }

    private void ShowResult(string result)
    {
        resultField.text = result;
        resultField.color = Color.white;   
    }

    private void PerformOperation(string operation)
    {
        if (!float.TryParse(a.text, out var aValue))
        {
            ShowError("Первое значение непонятно");
            return;
        }

        if (!float.TryParse(b.text, out var bValue) )
        {
            ShowError("Второе значение непонятно");
            return;
        }

        var result = 0f;
        switch (operation)
        {
            case Plus:
                result = aValue + bValue;
                break;
            case Minus:
                result = aValue - bValue;
                break;
            case Multiply:
                result = aValue * bValue;
                break;
            case Divide:
                if (bValue == 0)
                {
                    ShowError("Второе значение не может быть равно нулю");
                    return;
                }
                result = aValue / bValue;
                break;
        }

        ShowResult(result.ToString(CultureInfo.InvariantCulture));
    }

    public void OnPlus()
    {
        PerformOperation(Plus);
    }

    public void OnMinus()
    {
        PerformOperation(Minus);
    }

    public void OnMultiply()
    {
        PerformOperation(Multiply);
    }

    public void OnDivide()
    {
        PerformOperation(Divide);
    }
}
 