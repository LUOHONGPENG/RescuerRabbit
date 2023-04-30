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
        imgFillHP.fillAmount = GameMgr.Instance.levelMgr.dataHP / 100F;
        imgFillTP.fillAmount = GameMgr.Instance.levelMgr.dataTP / 100F;
    }
}
