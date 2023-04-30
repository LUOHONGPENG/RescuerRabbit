using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    public BoxCollider triggerUp;
    public BoxCollider triggerSave;
    public CharacterBasic characterBasic;
    public Transform tfNPC;
    public GameObject pfNPC;

    private float timerNPCGenerate = 0;
    private bool isInit = false;
    public NPCBasic catchNPC;
    //Data
    public int countSave = 0;
    public float dataTP = 100f;


    public void Init()
    {
        characterBasic.Init();
        countSave = 0;
        timerNPCGenerate = 0;
        isInit = true;
    }

    private void Update()
    {

        if (isInit)
        {
            TimeGoCheckRoop();
            TimeGoCheckSave();
            TimeGoGenerateNPC();
            TimeCheckTP();
        }
    }

     #region Time
    public void TimeGoCheckRoop()
    {
        Collider[] hits = Physics.OverlapBox(triggerUp.gameObject.transform.position + triggerUp.center, triggerUp.size / 2);

        foreach (var hit in hits)
        {
            if (hit.tag == "NPC")
            {
                NPCBasic NPC = hit.GetComponent<NPCBasic>();
                if (NPC != null)
                {
                    NPC.state = NPCBasic.NPCState.Up;
                    if(catchNPC == NPC)
                    {
                        catchNPC = null;
                    }
                }
            }
        }
    }

    public void TimeGoCheckSave()
    {
        Collider[] hits = Physics.OverlapBox(triggerSave.gameObject.transform.position + triggerSave.center, triggerSave.size / 2);

        foreach (var hit in hits)
        {
            if (hit.tag == "NPC")
            {
                NPCBasic NPC = hit.GetComponent<NPCBasic>();
                if (NPC != null)
                {
                    Destroy(NPC.gameObject);
                    countSave++;
                }
            }
        }
    }

    public void TimeGoGenerateNPC()
    {
        timerNPCGenerate -= Time.deltaTime;
        if (timerNPCGenerate < 0)
        {
            float posX = Random.Range(0f, 0.3f);
            float posZ = Random.Range(-0.6f, -0.3f);
            Vector3 posNPC = new Vector3(posX,0, posZ);
            CreateNPC(posNPC);
            timerNPCGenerate = 10f;
        }
    }

    public void TimeCheckTP()
    {
        if (catchNPC != null)
        {
            dataTP -= Time.deltaTime * 4f;
            if (dataTP < 0)
            {
                catchNPC.state = NPCBasic.NPCState.Free;
                catchNPC = null;
            }
        }
        else
        {
            if (dataTP < 100f)
            {
                dataTP += Time.deltaTime * 8f;
            }
        }
    }
    #endregion 

    public void CreateNPC(Vector3 pos)
    {
        GameObject objNPC = GameObject.Instantiate(pfNPC, tfNPC);
        objNPC.transform.localPosition = pos;
        NPCBasic itemNPC = objNPC.GetComponent<NPCBasic>();
        itemNPC.Init();
    }
}
