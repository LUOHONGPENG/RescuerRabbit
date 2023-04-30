using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBasic : MonoBehaviour
{
    public enum NPCState
    {
        Free,
        Catch,
        Up
    }

    public Transform tfNPC;
    public NPCState state;

    public void Init()
    {
        state = NPCState.Free;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case NPCState.Free:
                tfNPC.transform.Translate(Vector3.left * Time.deltaTime * 0.05f);
                break;
            case NPCState.Up:
                tfNPC.transform.Translate(Vector3.up * Time.deltaTime * 0.05f);
                break;
            case NPCState.Catch:
                tfNPC.transform.Translate((GameMgr.Instance.levelMgr.characterBasic.transform.position - this.transform.position) * Time.deltaTime * 1f);
                break;
        }
    }
}
