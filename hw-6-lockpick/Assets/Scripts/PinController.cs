using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PinController : MonoBehaviour
{
    /// <summary>
    /// Трансформ для кончика (будет меняться размер и позиция)
    /// </summary>
    [SerializeField] private RectTransform tipTransform;
    
    /// <summary>
    /// Трансформ для бочонка (будет меняться позиция)
    /// </summary>
    [SerializeField] private RectTransform pinTransform;
    
    /// <summary>
    /// Трансформ для пружины (будет меняться размер)
    /// </summary>
    [SerializeField] private RectTransform springTransform;
    
    /// <summary>
    /// Текст для отображения текущей позициии пина 
    /// </summary>
    [SerializeField] private TMP_Text pinPositionText;

    /// <summary>
    /// Позиция пина
    /// </summary>
    public int pinPosition = 0;
    
    /// <summary>
    /// Предыдущая позиция пина
    /// </summary>
    private int _lastPosition = 0;
    
    /// <summary>
    /// Крайнее верхнее положение пина
    /// </summary>
    private const int MaxPinPosition = 4;
    
    /// <summary>
    /// Крайнее нижнее положение пина
    /// </summary>
    private const int MinPinPosition = -4;

    /// <summary>
    /// Размер наконечника пина
    /// </summary>
    private int _tipSize = 2;
    
    /// <summary>
    /// Величина шага пина
    /// </summary>
    private float _stepSize;

    void Start()
    {
        _stepSize = 8f;
        InitPin();
    }

    /// <summary>
    /// Инициализация пина
    /// </summary>
    public void InitPin()
    {
        _tipSize = Random.Range(1, MaxPinPosition - 1);
        pinPosition = MaxPinPosition - _tipSize;

        UpdateInterface();
    }

    /// <summary>
    /// Обновление внешнего вида пина в зависимости от его положения
    /// </summary>
    private void UpdateInterface()
    {
        pinPositionText.text = pinPosition.ToString();

        var shift = _stepSize * pinPosition;
        tipTransform.sizeDelta = new Vector2(30, 17 + _stepSize * _tipSize);
        tipTransform.localPosition = new Vector3(0, 2 + shift, 0);
        pinTransform.localPosition = new Vector3(0, -30 + shift, 0);
        springTransform.sizeDelta = new Vector2(30, 50 + shift);
    }

    /// <summary>
    /// Выполнить сдвиг пина
    /// </summary>
    /// <param name="value">На какую величину выполнить сдвиг (целое число)</param>
    public void MovePin(int value)
    {
        _lastPosition = pinPosition;
        pinPosition = Math.Min(Math.Max(MinPinPosition, pinPosition + value), MaxPinPosition);
        UpdateInterface();
    }
}
