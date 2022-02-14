using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform target;
    public ParticleSystem slashEffect;
    public GameObject weapon;
    public float attackDistanceOffset;
    public bool isAttacking;

    PlayerRotation PR;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PR = GetComponent<PlayerRotation>();
        UpdateCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (attackCoroutine != null)
                StopCoroutine(attack());
            if (!isAttacking)
            {
                if(target) {
                    Vector3 dirToEnemy = (transform.position - target.position).normalized;
                    Vector3 newPos = target.position + (dirToEnemy* attackDistanceOffset);
                    transform.DOMove(newPos, 0.2f);
                    transform.LookAt(target);
                    //target = null;
                } else
                    PR.LookAtCamera();
            }
            StartCoroutine(attack());

            anim.SetTrigger("attack");
        }
    }

    public void UpdateCurrentWeapon()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    Coroutine attackCoroutine;
    public IEnumerator attack()
    {
        PR.canRotate = false;
        isAttacking = true;
        yield return new WaitForSeconds(2f);
        PR.canRotate = true;
        isAttacking = false;

    }
    public void Hit(float rotation)
    {
        slashEffect.Play();
        if(currentWeapon.hit)
        {
            currentWeapon.hit.GetComponent<Health>()?.TakeDamage(1);
        }
    }
}
