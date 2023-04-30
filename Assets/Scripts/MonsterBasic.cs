using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBasic : MonoBehaviour
{
    public BoxCollider colKill;
    public SpriteRenderer srMonster;

    public void Init() { }

    public void Update()
    {
        TimeGoCheckKill();
    }

    public void TimeGoCheckKill()
    {
        Collider[] hits = Physics.OverlapBox(colKill.gameObject.transform.position + colKill.center, 0.1f * colKill.size / 2);

        foreach (var hit in hits)
        {
            if (hit.tag == "NPC")
            {
                NPCBasic NPC = hit.GetComponent<NPCBasic>();
                if (NPC != null && !NPC.isDead)
                {
                    NPC.dataHP -= Time.deltaTime * 15f;
                }
            }
            else if(hit.tag == "Player")
            {
                GameMgr.Instance.levelMgr.dataHP -= Time.deltaTime * 10f;
            }
        }
    }

    public void FixedUpdate()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * 0.002f);
        colKill.transform.Translate(Vector3.right * Time.deltaTime * 0.002f);

    }
}
