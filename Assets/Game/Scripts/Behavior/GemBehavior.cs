using DG.Tweening;
using UnityEngine;

public class GemBehavior : MonoBehaviour
{
    [SerializeField]
    private EnumGemType _gemType;
    private Transform _target;
    private bool _moveToPlayer;

    private void Update()
    {
        transform.Rotate(0, 15 * Time.deltaTime, 0);
        if (_moveToPlayer)
        {
            float step = 25f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.position + new Vector3(0, 2, 0), step);
            if(transform.position == _target.position + new Vector3(0, 2, 0))
            {
                _target.GetComponent<PlayerBehaviour>().Retrieve(_gemType);
                Destroy(gameObject);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            GoToTarget(other.transform);
            
        }
    }

    private void GoToTarget(Transform target)
    {
        _target = target;
        _moveToPlayer = true;
    }
}