using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUIMgr : MonoBehaviour
{
    public Image imgFillHP;
    public Image imgFillTP;

    public Text codeSave;

    public void Init()
    {

    }

    private void Update()
    {
        codeSave.text = GameMgr.Instance.levelMgr.countSave.ToString();
    }
}
