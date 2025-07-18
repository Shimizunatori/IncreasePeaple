using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private Image _clockImage;
    // Start is called before the first frame update
    void Start()
    {
        _clockImage = GetComponent<Image>();
    }

    public void UpdateClock(float _sec)
    {
        _clockImage.fillAmount = _sec;
    }
}
