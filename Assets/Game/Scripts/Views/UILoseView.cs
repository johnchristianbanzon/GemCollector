using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UILoseView : MonoBehaviour, IScreen
{
    [SerializeField]
    private Button _playAgainButton;
    [Inject]
    private GameManager _gameManager;

    private void Awake()
    {
        _playAgainButton.onClick.AddListener(OnClickPlayAgain);
    }

    private void OnClickPlayAgain()
    {
        _gameManager.PlayAgain();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}