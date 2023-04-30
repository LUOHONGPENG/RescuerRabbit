using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    public BoxCollider triggerSave;
    public CharacterBasic characterBasic;
    public Transform tfNPC;
    public GameObject pfNPC;

    private float timerNPCGenerate = 0;
    private bool isInit = false;

    public void Init()
    {
        timerNPCGenerate = 0;

        isInit = true;
    }

    private void Update()
    {
        if (isInit)
        {
            TimeGoCheckRoop();
            TimeGoGenerateNPC();
        }
    }

    public void TimeGoCheckRoop()
    {

    }

    public void TimeGoGenerateNPC()
    {
        timerNPCGenerate -= Time.deltaTime;
        if (timerNPCGenerate < 0)
        {
            float posX = Random.Range(0f, 0.3f);
            float posZ = Random.Range(-0.6f, -0.3f);
            Vector2 posNPC = new Vector2(posX, posZ);
            CreateNPC(posNPC);

            timerNPCGenerate = 10f;
        }
        

    }

    public void CreateNPC(Vector2 pos)
    {
        Debug.Log("GenerateNPC");
        Vector3 posGenerate = new Vector3(pos.x, -0.35f, pos.y);
        GameObject objNPC = GameObject.Instantiate(pfNPC, tfNPC);
        NPCBasic itemNPC = objNPC.GetComponent<NPCBasic>();
        itemNPC.Init();
    }
}
