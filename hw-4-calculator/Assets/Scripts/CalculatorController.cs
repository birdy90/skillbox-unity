using System.Globalization;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    /// <summary>
    /// Плейсхоледр результата
    /// </summary>
    [SerializeField] private string resultPlaceholder = "...";
    
    /// <summary>
    /// Ссылка на поле с результатом
    /// </summary>
    [SerializeField] private TMP_Text resultField;
    
    /// <summary>
    /// Ссылка на поле ввода первого числа
    /// </summary>
    [SerializeField] private TMP_InputField a;
    
    /// <summary>
    /// Ссылка на поле ввода второго числа
    /// </summary>
    [SerializeField] private TMP_InputField b;
    
    /// <summary>
    /// Операция сложения
    /// </summary>
    private const string Plus = "+";
    
    /// <summary>
    /// Операция вычитания
    /// </summary>
    private const string Minus = "-";
    
    /// <summary>
    /// Операция умножения
    /// </summary>
    private const string Multiply = "*";
    
    /// <summary>
    /// Операция деления
    /// </summary>
    private const string Divide = "/";
    
    /// <summary>
    /// Инициализация компонента
    /// </summary>
    void Start()
    {
        resultField.text = resultPlaceholder;
    }

    /// <summary>
    /// Показать ошибку
    /// </summary>
    /// <param name="error">Текст ошибки</param>
    private void ShowError(string error)
    {
        resultField.text = error;
        resultField.color = Color.red;   
    }

    /// <summary>
    /// Показать результат
    /// </summary>
    /// <param name="result">Текст результата</param>
    private void ShowResult(string result)
    {
        resultField.text = result;
        resultField.color = Color.white;   
    }

    /// <summary>
    /// Выполнить вычисление
    /// </summary>
    /// <param name="operation">Тип выполняемой операции</param>
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

    /// <summary>
    /// Вызов сложения
    /// </summary>
    public void OnPlus()
    {
        PerformOperation(Plus);
    }

    /// <summary>
    /// Вызов вычитания
    /// </summary>
    public void OnMinus()
    {
        PerformOperation(Minus);
    }

    /// <summary>
    /// Вызов умножения
    /// </summary>
    public void OnMultiply()
    {
        PerformOperation(Multiply);
    }

    /// <summary>
    /// Вызов деления
    /// </summary>
    public void OnDivide()
    {
        PerformOperation(Divide);
    }
}
 