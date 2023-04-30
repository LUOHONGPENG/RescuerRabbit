using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIMgr : MonoBehaviour
{
    public GameObject objPopup;
    public Button btnStart;

    public void Init()
    {
        btnStart.onClick.RemoveAllListeners();
        btnStart.onClick.AddListener(delegate ()
        {
            objPopup.SetActive(false);
            Time.timeScale = 1f;
        });

        objPopup.SetActive(true);
        Time.timeScale = 0;
    }



}
