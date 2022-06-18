using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MessageController : MonoBehaviour
{
    /// <summary>
    /// Ссылка на текст для звука-действия
    /// </summary>
    [SerializeField] private GameObject doorSoundPanel;
    
    /// <summary>
    /// Ссылка на текст звука-действия
    /// </summary>
    [SerializeField] private TMP_Text doorSoundText;
    
    /// <summary>
    /// Ссылка на картинку звука-действия (для изменения положения)
    /// </summary>
    [SerializeField] private Image doorSoundImage;
    
    /// <summary>
    /// Ссылка на текст сообщения
    /// </summary>
    [SerializeField] private TMP_Text chatText;

    /// <summary>
    /// Время последнего включения звука-действия
    /// </summary>
    private float _lastDoorSoundTime = 0f;
    
    /// <summary>
    /// Длительность отображения звука-действия
    /// </summary>
    private float _doorSoundDuration = 0.5f;
    
    /// <summary>
    /// Время последнего включения сообщения 
    /// </summary>
    private float _lastChatTime = 0f;
    
    /// <summary>
    /// Длительность показа сообщения
    /// </summary>
    private float _chatDuration = 3f;

    /// <summary>
    /// Сбрасываем сообщения
    /// </summary>
    void Start()
    {
        SetDoorSound("");
        SetChat("");
    }

    /// <summary>
    /// Проверяем таймеры
    /// </summary>
    void Update()
    {
        if (Time.time - _lastDoorSoundTime >= _doorSoundDuration)
        {
            SetDoorSound("");
        }
        
        if (Time.time - _lastChatTime >= _chatDuration)
        {
            SetChat("");
        }
    }

    /// <summary>
    /// Установить звук-действие
    /// </summary>
    /// <param name="soundText">Текст для отображения звука</param>
    public void SetDoorSound(string soundText)
    {
        if (soundText == "")
        {
            doorSoundPanel.SetActive(false);
        }
        else
        {
            _lastDoorSoundTime = Time.time;
            doorSoundPanel.SetActive(true);
            doorSoundText.text = soundText;
            doorSoundImage. transform.rotation = Quaternion.identity;
            doorSoundImage.transform.Rotate(0, 0, MathF.Round(Random.Range(-2, 2) * 5));
        }
    }

    /// <summary>
    /// Уставновить сообщение
    /// </summary>
    /// <param name="soundText">Текст сообщения</param>
    public void SetChat(string soundText)
    {
        if (soundText == "")
        {
            chatText.gameObject.SetActive(false);
        }
        else
        {
            _lastChatTime = Time.time;
            chatText.gameObject.SetActive(true);
            chatText.text = soundText;
        }
    }
}
