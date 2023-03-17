using UnityEngine;
using UnityEngine.UI;

// ������ ��� ������ ������������� ����� � ������ �����
public class ShopButton : MonoBehaviour
{

    [SerializeField] private Button _button;
    [SerializeField] private Resources _resources;
    [SerializeField] private int _price;
    [SerializeField] private Clickable _�lickable;

    private void Start()
    {
        _button.onClick.AddListener(Buy);
    }

    private void UpdateButtonState(int coins) {
        _button.interactable = coins >= _price;
    }

    public void Buy() {
        if (_resources.TryBuy(_price)) {
            _�lickable.AddCoinsPerClick(1);
        }
    }

    private void OnEnable()
    {
        _resources.OnChangeCoins += UpdateButtonState;
    }

    private void OnDisable()
    {
        _resources.OnChangeCoins -= UpdateButtonState;
    }

}
