using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    public Transform tfCharacter;
    public SpriteRenderer srCharacter;

    public GameObject aniCatch;
    public CapsuleCollider triCatch;

    public void Init()
    {
        aniCatch.gameObject.SetActive(false);
    }


    private void FixedUpdate()
    {
        float moveRate = Time.deltaTime * 0.3f;

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

            Collider[] hits = Physics.OverlapSphere(triCatch.gameObject.transform.position + triCatch.center, triCatch.radius);

            foreach (var hit in hits)
            {
                if (hit.tag == "NPC")
                {
                    Debug.Log("NPC");
                    NPCBasic NPC = hit.GetComponent<NPCBasic>();
                    if (NPC != null)
                    {
                        NPC.state = NPCBasic.NPCState.Catch;
                        GameMgr.Instance.levelMgr.catchNPC = NPC;
                    }
                }
            }
        }
    }

    public IEnumerator IE_ShowTip()
    {
        aniCatch.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        aniCatch.gameObject.SetActive(false);
    }
}
