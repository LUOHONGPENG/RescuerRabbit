using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    public Transform tfCharacter;
    public SpriteRenderer srCharacter;

    public Animator aniCatch;
    public CapsuleCollider triCatch;

    private float dataHPLast;

    public void Init()
    {
        aniCatch.gameObject.SetActive(false);
        dataHPLast = GameMgr.Instance.levelMgr.dataHP;

    }


    private void FixedUpdate()
    {
        float moveRate = Time.deltaTime * 0.3f;
        if (GameMgr.Instance.levelMgr.catchNPC != null)
        {
            moveRate = moveRate * 0.25f;
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            tfCharacter.transform.Translate(Vector3.right * moveRate);
            srCharacter.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            tfCharacter.transform.Translate(Vector3.left * moveRate);
            srCharacter.flipX = false;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            tfCharacter.transform.Translate(Vector3.forward * moveRate);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            tfCharacter.transform.Translate(Vector3.back * moveRate);
        }
    }

    private void Update()
    {

        if (Input.GetButtonDown("Catch") && GameMgr.Instance.levelMgr.catchNPC==null)
        {
            StartCoroutine(IE_ShowTip());

            GameMgr.Instance.soundMgr.PlaySoundCatch();

            Collider[] hits = Physics.OverlapSphere(triCatch.gameObject.transform.position + triCatch.center, triCatch.radius * 0.1f);

            foreach (var hit in hits)
            {
                if (hit.tag == "NPC")
                {
                    NPCBasic NPC = hit.GetComponent<NPCBasic>();
                    if (NPC != null && NPC.state == NPCBasic.NPCState.Free && !NPC.isDead)
                    {
                        NPC.state = NPCBasic.NPCState.Catch;
                        GameMgr.Instance.levelMgr.catchNPC = NPC;
                        break;
                    }
                }
            }
        }

        if (GameMgr.Instance.levelMgr.dataHP < dataHPLast)
        {
            srCharacter.color = Color.red;
            dataHPLast = GameMgr.Instance.levelMgr.dataHP;
        }
        else
        {
            srCharacter.color = Color.white;
        }


    }

    public IEnumerator IE_ShowTip()
    {
        aniCatch.gameObject.SetActive(true);
        aniCatch.Play("AniCatch",0,-1f);
        yield return new WaitForSeconds(0.5f);
        aniCatch.gameObject.SetActive(false);
    }
}
