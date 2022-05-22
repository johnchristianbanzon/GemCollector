using System.Collections;
using UnityEngine;
using Zenject;

public class AIThiefAlienBehavior : MonoBehaviour
{
    [Inject]
    private PlayerManager _player;
    private Transform _targetPlayer;
    [SerializeField]
    private float _speed = 1.4f;
    private bool _pauseChase;

    private void Awake()
    {
        _targetPlayer = _player.GetPlayer().GetTransform();
    }
    // Update is called once per frame
    private void Update()
    {
        if (_pauseChase)
        {
            return;
        }
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, _targetPlayer.transform.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(transform.position - _targetPlayer.position);
    }

    private void OnPlayerHit()
    {
        _pauseChase = true;
        StartCoroutine("ResumeChaseCountdown");
    }

    private IEnumerator ResumeChaseCountdown()
    {
        yield return new WaitForSeconds(2f);
        ResumeChase();
    }

    private void ResumeChase()
    {
        _pauseChase = false;
    }

    public void PauseChase()
    {
        _pauseChase = true;
        StopCoroutine("ResumeChaseCountdown");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnPlayerHit();
            collision.gameObject.GetComponent<PlayerBehaviour>().HitPlayer();
        }
    }
}
