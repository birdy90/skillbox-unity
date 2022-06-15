using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabController: MonoBehaviour
{
    private static TabController _currentTab;
    [SerializeField] private string tabTitle; 
    [SerializeField] private GameObject containerObject;
    
    [Header("Prefab settings")]
    [SerializeField] private Button button; 
    [SerializeField] private TMP_Text buttonText; 


    private void Start()
    {
        buttonText.text = tabTitle;
        if (containerObject.activeSelf)
        {
            _currentTab = this;
            button.interactable = false;
        }
    }

    private void SetActive(bool value)
    {
        button.interactable = !value;
        containerObject.SetActive(value);
    }

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