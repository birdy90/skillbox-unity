using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabController: MonoBehaviour
{
    /// <summary>
    /// Поле для запоминания текущей вкладки
    /// </summary>
    private static TabController _currentTab;
    
    /// <summary>
    /// Надпись на вкладке
    /// </summary>
    [SerializeField] private string tabTitle;
    
    /// <summary>
    /// Объект с данными, который будет переключаться по нажатию вкладки
    /// </summary>
    [SerializeField] private GameObject containerObject;
    
    /// <summary>
    /// Ссылка на кнопку вкладки
    /// </summary>
    [Header("Prefab settings")]
    [SerializeField] private Button button;
    
    /// <summary>
    /// Ссылка на текст кнопки вкладки
    /// </summary>
    [SerializeField] private TMP_Text buttonText; 

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Start()
    {
        buttonText.text = tabTitle;
        if (containerObject.activeSelf)
        {
            _currentTab = this;
            button.interactable = false;
        }
    }

    /// <summary>
    /// Делаем вкладку активной или неактивной
    /// </summary>
    /// <param name="value">Целевое состояние вкладки</param>
    private void SetActive(bool value)
    {
        button.interactable = !value;
        containerObject.SetActive(value);
    }

    /// <summary>
    /// Обработка нажатия на вкладку
    /// </summary>
    public void OnClick()
    {
        if (_currentTab)
        {
            _currentTab.SetActive(false);
        }

        SetActive(true);
        _currentTab = this;
    }
}