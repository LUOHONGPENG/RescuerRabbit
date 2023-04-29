using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public LevelMgr levelMgr;
    public UIMgr uiMgr;

    public void Init()
    {
        levelMgr.Init();
    }
}
