using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetList : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GM.RemoveList();
    }
}
