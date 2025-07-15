using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("生成する人間たち")] private List<GameObject> _peaple = new List<GameObject>();
    [Header("場に存在する人間たち")] public List<GameObject> _peapleList = new List<GameObject>();
    [SerializeField, Header("最大人間数")] private int _maxPeaple;
    [SerializeField, Header("ビルたち")] private List<GameObject> _buildList = new List<GameObject>();
    private int _peapleCount;
    public int _score;
    // Start is called before the first frame update
    void Start()
    {
        //_buildList
    }

    // Update is called once per frame
    void Update()
    {
        var _randomPeaple = Random.Range(0, 4);
        if (_peapleList.Count < _maxPeaple)
        {
            Debug.Log("Spawn");
            var _person = Instantiate(_peaple[_randomPeaple], transform.position, Quaternion.identity);
            _person.transform.parent = transform;
            _peapleList.Add(_person);
            _person.gameObject.GetComponent<SpriteRenderer>().sortingOrder = _randomPeaple;
        }
    }
}
