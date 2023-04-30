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
    public Rigidbody thisBody;
    public CapsuleCollider colNPC;
    public NPCState state;
    public Animator aniDead;

    public float dataHP = 50F;
    public bool isDead = false;

    public void Init()
    {
        state = NPCState.Free;
        aniDead.enabled = false;
    }

    private void Update()
    {
        if (dataHP < 0 && !isDead)
        {
            StartCoroutine(IE_Kill());
            isDead = true;
        }
    }

    public IEnumerator IE_Kill()
    {
        aniDead.enabled = true;
        if (this == GameMgr.Instance.levelMgr.catchNPC)
        {
            GameMgr.Instance.levelMgr.catchNPC = null;
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        switch (state)
        {
            case NPCState.Free:
                tfNPC.transform.Translate(Vector3.left * Time.deltaTime * 0.05f);
                colNPC.isTrigger = false;
                thisBody.useGravity = true;
                break;
            case NPCState.Up:
                thisBody.velocity = Vector3.zero;
                tfNPC.transform.Translate(Vector3.up * Time.deltaTime * 0.1f);
                thisBody.useGravity = false;
                break;
            case NPCState.Catch:
                tfNPC.transform.Translate((GameMgr.Instance.levelMgr.characterBasic.transform.position - this.transform.position) * Time.deltaTime * 1f);
                thisBody.useGravity = false;
                colNPC.isTrigger = true;
                break;
        }
    }
}
