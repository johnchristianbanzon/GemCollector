using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FloatingPointsView : MonoBehaviour
{
    private Transform _target;
    [SerializeField]
    private Text _pointsText;
    private bool _isShowing;

    public bool GetIsShowing()
    {
        return _isShowing;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Show(int points)
    {
        _pointsText.text = "+"+points.ToString();
        gameObject.SetActive(true);
        _isShowing = true;
        var worldPos = Camera.main.WorldToScreenPoint(_target.position);
        transform.position = worldPos;
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
        _pointsText.DOFade(0, 0.005f);
        _pointsText.DOFade(1, 0.2f).OnComplete(delegate {
            _pointsText.DOFade(0, 0.3f);
        });
        transform.DOMoveY(transform.position.y + 6f, 0.4f).SetEase(Ease.Linear).OnComplete(delegate {
            Hide();
        });
    }

    public void Hide()
    {
        
        gameObject.SetActive(false);
        _isShowing = false;
    }

}
