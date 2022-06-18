using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Первый пин замка
    /// </summary>
    public PinController pin1;
    
    /// <summary>
    /// Второй пин замка
    /// </summary>
    public PinController pin2;
    
    /// <summary>
    /// Третий пин замка
    /// </summary>
    public PinController pin3;

    /// <summary>
    /// Контроллер сообщений
    /// </summary>
    public MessageController messageController;

    /// <summary>
    /// Ссылка на панель с финальным экраном
    /// </summary>
    public GameObject finalScreen;
    
    /// <summary>
    /// Ссылка на заголовок финального экрана
    /// </summary>
    public TMP_Text finalTitle;
    
    /// <summary>
    /// Ссылка на текст финального экрана
    /// </summary>
    public TMP_Text finalDescription;
    
    /// <summary>
    /// Прямоугольник трансформации таймера (для масштабирования)
    /// </summary>
    public RectTransform timerTransform;
    
    /// <summary>
    /// Текст таймера
    /// </summary>
    public TMP_Text timerText;

    /// <summary>
    /// Работает ли таймер
    /// </summary>
    private bool _timerIsWorking = false;
    
    /// <summary>
    /// Время начала райнда
    /// </summary>
    private float _gameStartedTime;
    
    /// <summary>
    /// Длительность одного раунда
    /// </summary>
    private float _gameSessionLength = 31f;

    /// <summary>
    /// Текущее значение счётчика
    /// </summary>
    public int CountdownValue => (int)MathF.Floor(_gameSessionLength - (Time.time - _gameStartedTime));

    void Update()
    {
        if (!_timerIsWorking)
        {
            return;
        }

        if (Time.time - _gameStartedTime >= _gameSessionLength)
        {
            GameFailed();
        }

        var portionPassed = 1 - CountdownValue / _gameSessionLength;
        var scale = 1f - 0.5f * MathF.Pow(portionPassed, 4) * MathF.Sin(2 * MathF.PI * (Time.time - _gameStartedTime));
        timerTransform.localScale = new Vector3(scale, scale, 0);
        timerText.text = CountdownValue.ToString();
    }
    
    /// <summary>
    /// Инициализация игры
    /// </summary>
    public void InitGame()
    {
        pin1.InitPin();
        pin2.InitPin();
        pin3.InitPin();
        _timerIsWorking = true;
        _gameStartedTime = Time.time;
    }

    /// <summary>
    /// Показать экран победы
    /// </summary>
    public void GameSuccessfull()
    {
        _timerIsWorking = false;
        finalTitle.text = "Йей, я дома";
        finalDescription.text =
            "Фух, столько мучений из-за одного потерянного ключа! Хорошо хоть руки на месте. Теперь осталось только новый замок купить!";
        finalScreen.SetActive(true);
    }

    /// <summary>
    /// Показать экран поражения
    /// </summary>
    public void GameFailed()
    {
        _timerIsWorking = false;
        finalTitle.text = "Ну вот, не вышло";
        finalDescription.text =
            "У меня нет больше сил ковыряться. Пойду к Коляну, может он умеет замки вскрывать. Ну или хотя бы переночую у него";
        finalScreen.SetActive(true);
    }

    /// <summary>
    /// Проверить состояние игры (чтобы показать экран победы или отобразить сообщения)
    /// </summary>
    public void CheckGameState()
    {
        var pins = new float[3] { pin1.pinPosition, pin2.pinPosition, pin3.pinPosition };
        
        if (pins.All(t => t == 0))
        {
            GameSuccessfull();
        }
        else if (pins.Count(t => t == 0) == 2)
        {
            if (pins.Count(t => (Math.Abs(t) - 1) < Single.Epsilon) == 1)
            {
                messageController.SetChat("Ну же, совсем капельку!");
            }
            else
            {
                messageController.SetChat("Таак, очень неплохо!");
            }
        }
        else if (pins.Any(t => t == 0))
        {
            messageController.SetChat("О, что-то получилось!");
        }
    }
}
