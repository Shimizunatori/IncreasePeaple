using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�l�Ԃ���")] private List<GameObject> _peaple = new List<GameObject>();
    [SerializeField, Header("�ő�l�Ԑ�")] private int _maxPeaple;
    private int _peapleCount;
    public int _score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
