using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndUIMgr : MonoBehaviour
{
    public GameObject objPopup;
    public Button btnRestart;
    public Text txScore;


    public void Init()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnRestart.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Main");
        });
    }

    public void Show()
    {
        Time.timeScale = 0;
        objPopup.SetActive(true);
        txScore.text = string.Format("You have saved {0} people! You are hero.",GameMgr.Instance.levelMgr.countSave);
    }
}
