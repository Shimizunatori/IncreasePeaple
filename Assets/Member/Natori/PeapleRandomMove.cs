using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeapleRandomMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region 宣言
    [SerializeField, Header("移動速度")]                private float _moveSpeed;
    //[SerializeField, Header("ゲームマネージャー")]      private GameManager GM;
    public float _timeUp;
    private Vector2 _enemyPos;
    private Vector2 _vec2;
    private float _vecX;
    private float _vecY;
    private float _moveTime;
    private float _leaveTime;
    private bool _moveFlag;
    private GameManager _gm;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _moveTime = 0;
        _leaveTime = 0;
        _moveFlag = true;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gm.GetComponent<GameManager>();
        _gm._gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm._gameEnd)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        if (!_moveFlag)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 1));
            this.transform.position = target;
        }
        if (_moveFlag)
        {
            _leaveTime += Time.deltaTime;
            if (_leaveTime >= _timeUp)
            {
                _gm._gameEnd = true;
            }
            _enemyPos = this.transform.position;
            _moveTime -= Time.deltaTime;
            if (_moveTime <= 0.0f)
            {
                var A = new Vector2(-5, -2);
                var B = new Vector2(5, 2);
                _vecX = Random.Range(A.x, B.x);
                _vecY = Random.Range(A.y, B.y);
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
    }

    //　マウスが押された時
    public void OnPointerDown(PointerEventData eventData)
    {
        _moveFlag = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //SE
        SEManager.Instance.PlaySe(SEType.SE1);
    }

    //　マウスが離された時
    public void OnPointerUp(PointerEventData eventData)
    {
        _moveFlag = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Build1":
                if (this.gameObject.CompareTag("Peaple1"))
                {
                    _gm._score++;
                    Destroy(gameObject);
                }
                else
                {
                    _gm._gameEnd = true;
                }
                break;
            case "Build2":
                if (this.gameObject.CompareTag("Peaple2"))
                {
                    _gm._score++;
                    Destroy(gameObject);
                }
                else
                {
                    _gm._gameEnd = true;
                }
                break;
            case "Build3":
                if (this.gameObject.CompareTag("Peaple3"))
                {
                    _gm._score++;
                    Destroy(gameObject);
                }
                else
                {
                    _gm._gameEnd = true;
                }
                break;
            case "Build4":
                if (this.gameObject.CompareTag("Peaple4"))
                {
                    _gm._score++;
                    Destroy(gameObject);
                }
                else
                {
                    _gm._gameEnd = true;
                }
                break;
        }
    }
}
