using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public InterfaceUIMgr interfaceUIMgr;
    public StartUIMgr startUIMgr;
    public EndUIMgr endUIMgr;


    public void Init()
    {
        interfaceUIMgr.Init();
        startUIMgr.Init();
        endUIMgr.Init();
    }
}
