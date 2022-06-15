using System;
using TMPro;
using UnityEngine;

public class CompareController : MonoBehaviour
{
    /// <summary>
    /// Плейсхолдер результата
    /// </summary>
    [SerializeField] private string resultPlaceholder = "...";
    
    /// <summary>
    /// Ссылка на поле результата
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
    /// Инициализация компонента
    /// </summary>
    void Start()
    {
        resultField.text = resultPlaceholder;
    }
    
    /// <summary>
    /// Показать ошибку
    /// </summary>
    private void ShowError()
    {
        resultField.text = "X";
        resultField.color = Color.red;   
    }

    /// <summary>
    /// Показать корректный результат
    /// </summary>
    /// <param name="result">Текст результата</param>
    private void ShowResult(string result)
    {
        resultField.text = result;
        resultField.color = Color.white;   
    }

    /// <summary>
    /// Выполнение сравнения чисел
    /// </summary>
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
 