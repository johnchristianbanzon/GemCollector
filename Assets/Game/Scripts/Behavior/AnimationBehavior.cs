using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private string _currentAnimation;

    public string GetCurrentAnimationString()
    {
        return _currentAnimation;
    }

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }


    public void Play(string animation) {
        
        if (_animator == null)
        {
            _animator = gameObject.GetComponent<Animator>();
        }
        _currentAnimation = animation;
        _animator.SetTrigger(animation);
    }
}
