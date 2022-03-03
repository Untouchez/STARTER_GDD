using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class PlayerVault : MonoBehaviour
{
    PlayerRotation PR;
    Animator anim;
    bool isVaulting;

    public void Start()
    {
        PR = GetComponent<PlayerRotation>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Vector3 vaultPos = checkVault();
            vaultPos.y = 0;
            if(vaultPos != Vector3.zero) {
                if(!isVaulting)
                    StartCoroutine(startVault(vaultPos));
            }
        }
    }

    IEnumerator startVault(Vector3 vaultPos)
    {
        isVaulting = true;
        PR.canRotate = false;
        GetComponent<Collider>().enabled = false;
        transform.DOMove(vaultPos, 0.5f);
        anim.SetTrigger("vault");
        yield return new WaitForSeconds(0.65f);

        NavMesh.SamplePosition(transform.position + ((transform.position - vaultPos).normalized*1.2f), out NavMeshHit hit, 2f, NavMesh.AllAreas);
        Vector3 endPos = hit.position;
        transform.DOMove(endPos, 0.5f);
        yield return new WaitForSeconds(0.35f);

        PR.canRotate = true;
        isVaulting = false;
        GetComponent<Collider>().enabled = true;
    }

    Vector3 checkVault()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + new Vector3(0,0.2f,0),transform.forward*10f, out hit,2f))     
            return hit.point;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), transform.forward + transform.right, out hit, 2f))
            return hit.point;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), transform.forward - transform.right, out hit, 2f))
            return hit.point;
        return Vector3.zero;
    }
}