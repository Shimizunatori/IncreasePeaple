using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeapleRandomMove : MonoBehaviour, IPointerClickHandler
{
    #region 宣言
    [SerializeField, Header("移動範囲A")]               private Transform _rangeA;
    [SerializeField, Header("移動範囲B")]               private Transform _rangeB;
    [SerializeField, Header("移動速度")]                private float _moveSpeed;
    [SerializeField, Header("ゲームマネージャー")]      private GameManager GM;
    private Vector2 _enemyPos;
    private Vector2 _vec2;
    private float _vecX;
    private float _vecY;
    private float _moveTime;
    private bool _moveFlag;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _moveTime = 0;
        _moveFlag = true;
        GM = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_moveFlag)
        {
            if (Input.GetMouseButton(0))
            {
                this.transform.position = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //SE
                _moveFlag = true;
            }
            return;
        }
        _enemyPos = this.transform.position;
        _moveTime -= Time.deltaTime;
        if (_moveTime <= 0.0f)
        {
            _vecX = Random.Range(_rangeA.transform.position.x, _rangeB.transform.position.x);
            _vecY = Random.Range(_rangeA.transform.position.y, _rangeB.transform.position.y);
            var _lastEnemyPos = _enemyPos;
            _vec2 = new Vector2(_vecX, _vecY);
            gameObject.GetComponent<Rigidbody2D>().velocity = (_vec2 - _lastEnemyPos).normalized * _moveSpeed;
            _moveTime = 1.0f;
        }
        if (Mathf.Approximately(_vec2.x, _enemyPos.x) && Mathf.Approximately(_vec2.y, _enemyPos.y))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _moveFlag = false;
        //SE
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GM._score++;
        switch (other.tag)
        {
            case "Build1":
                if (this.gameObject.CompareTag("Peaple1"))
                {
                    Destroy(gameObject);
                }
                break;
            case "Build2":
                if (this.gameObject.CompareTag("Peaple2"))
                {
                    Destroy(gameObject);
                }
                break;
            case "Build3":
                if (this.gameObject.CompareTag("Peaple3"))
                {
                    Destroy(gameObject);
                }
                break;
            case "Build4":
                if (this.gameObject.CompareTag("Peaple4"))
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
