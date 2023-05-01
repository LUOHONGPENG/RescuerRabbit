using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;

    public void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        levelMgr.Init();
        uiMgr.Init();
        soundMgr.Init();
    }
}
