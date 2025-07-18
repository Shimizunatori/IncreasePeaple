using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("生成する人間たち")]    private List<GameObject> _peaple = new List<GameObject>();
    [Header("場に存在する人間たち")]                public List<GameObject> _peapleList = new List<GameObject>();
    [SerializeField, Header("最大人間数")]          private int _maxPeaple;
    [SerializeField, Header("ビルたち")]            private List<GameObject> _buildList = new List<GameObject>();
    [SerializeField]                                private GameObject _result;
    public int _score;
    public int _levelUpLine;
    public bool _gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        _buildList[0].SetActive(true);
        _buildList[1].SetActive(true);
        _score = 0;
        _gameEnd = false;
        _result.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_peapleList.Count < _maxPeaple)
        {
            if (_score < _levelUpLine)
            {
                var _randomPeaple = Random.Range(0, 2);
                Debug.Log("Spawn");
                var _person = Instantiate(_peaple[_randomPeaple], transform.position, Quaternion.identity);
                //_person.transform.parent = transform;
                _peapleList.Add(_person);
                _person.gameObject.GetComponent<SpriteRenderer>().sortingOrder = _randomPeaple;
            }
            if (_score >= _levelUpLine)
            {
                _buildList[2].SetActive(true);
                _buildList[3].SetActive(true);
                _maxPeaple = 5;
                var _randomPeaple = Random.Range(0, 4);
                Debug.Log("Spawn");
                var _person = Instantiate(_peaple[_randomPeaple], transform.position, Quaternion.identity);
                //_person.transform.parent = transform;
                _peapleList.Add(_person);
                _person.gameObject.GetComponent<SpriteRenderer>().sortingOrder = _randomPeaple;
            }
        }

        if (_gameEnd)
        {
            //ゲームオーバー処理
            _result.SetActive(true);
        }
    }

    public async void RemoveList()
    {
        await Task.Delay(120);
        for (int i = 0; i <= _peapleList.Count - 1; i++)
        {
            if (_peapleList[i] == null)
            {
                _peapleList.RemoveAt(i);
            }
        }
    }
}
