using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("��������l�Ԃ���")] private List<GameObject> _peaple = new List<GameObject>();
    [Header("��ɑ��݂���l�Ԃ���")] public List<GameObject> _peapleList = new List<GameObject>();
    [SerializeField, Header("�ő�l�Ԑ�")] private int _maxPeaple;
    [SerializeField, Header("�r������")] private List<GameObject> _buildList = new List<GameObject>();
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
