using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Действия игрока, кнопки, по которым игрок может воздействовать на пины замка
/// </summary>
public class ActionComponent : MonoBehaviour
{
    /// <summary>
    /// Заголовок дейтсвия
    /// </summary>
    public string title;

    /// <summary>
    /// Изменение первого пина при нажатии
    /// </summary>
    public int firstPinValue;
    
    /// <summary>
    /// Изменение второго пина при нажатии
    /// </summary>
    public int secondPinValue;
    
    /// <summary>
    /// Изменение третьего пина при нажатии
    /// </summary>
    public int thirdPinValue;

    /// <summary>
    /// Ссылка на игровой контролле
    /// </summary>
    public GameController gameController;

    /// <summary>
    /// Ссылка на текст подписи на кнопке
    /// </summary>
    [SerializeField] private TMP_Text captionText;
    
    /// <summary>
    /// Ссылка на текст подписи со значениями, на которые изменятся положения пинов
    /// </summary>
    [SerializeField] private TMP_Text pinValuesText;
    
    void Start()
    {
        captionText.text = title;
        pinValuesText.text = $"{firstPinValue} / {secondPinValue} / {thirdPinValue}";
    }

    /// <summary>
    /// Выполнить действие при нажатии на кнопку
    /// </summary>
    public void PerformAction()
    {
        if (gameController == null)
        {
            Debug.LogError($"Game controller is not set for action '{title}'");
            return;
        }
        
        gameController.pin1.MovePin(firstPinValue);
        gameController.pin2.MovePin(secondPinValue);
        gameController.pin3.MovePin(thirdPinValue);
    }
}
