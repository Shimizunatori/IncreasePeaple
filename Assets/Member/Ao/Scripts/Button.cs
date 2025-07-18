using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnButtonClickStart()
    {
        SEManager.Instance.PlaySe(SEType.SE2);
        SceneManager.LoadScene("Main");
        SEManager.Instance.StopBgm();
        SEManager.Instance.PlayBgm(BGMType.BGM2);
    }

    public void OnButtonClickTitleBack()
    {
        SEManager.Instance.PlaySe(SEType.SE2);
        SceneManager.LoadScene("TitleScene");
        SEManager.Instance.StopBgm();
        SEManager.Instance.PlayBgm(BGMType.BGM2);
    }
}