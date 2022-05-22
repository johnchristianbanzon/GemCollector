
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GemSpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private EnumGemType _spawnGemType;
    [SerializeField]
    private PointLight _pointLight;

    private void Awake()
    {
        StartCoroutine("StartSpawnGemTimer");
    }

    private IEnumerator StartSpawnGemTimer()
    {
        yield return new WaitForSeconds(GetGemTimer());
        SpawnGem();
        StartCoroutine("StartSpawnGemTimer");
    }

    private void SpawnGem() {
        var locationRangeOffset = 4f;
        var currentLocation = transform.transform.position;
        var randomXSpot = Random.Range(currentLocation.x - locationRangeOffset, currentLocation.x + locationRangeOffset);
        var randomZSpot = Random.Range(currentLocation.z - locationRangeOffset, currentLocation.z + locationRangeOffset);
        var randomSpotNearby = new Vector3(System.Math.Abs(randomXSpot)<2 ? randomXSpot * 2.2f : randomXSpot, 1.3f, System.Math.Abs(randomZSpot) < 2 ? randomZSpot * 2.2f : randomZSpot);
        var spawnGem = Instantiate(Resources.Load("Prefabs/" + _spawnGemType.ToString())) as GameObject;
        spawnGem.transform.position = transform.position;
        spawnGem.transform.DOJump(randomSpotNearby,2f,1,1.1f).SetEase(Ease.OutBounce);
    }


    private float GetGemTimer()
    {
        var time = 0f;
        switch (_spawnGemType)
        {
            case EnumGemType.Ruby:
                time = 4f;
                break;
            case EnumGemType.Sapphire:
                time = 6f;
                break;
            case EnumGemType.Emerald:
                time = 8f;
                break;
            case EnumGemType.Garnet:
                time = 9f;
                break;
            case EnumGemType.Gold:
                time = 11f;
                break;
        }
        return time;
    }
    
}