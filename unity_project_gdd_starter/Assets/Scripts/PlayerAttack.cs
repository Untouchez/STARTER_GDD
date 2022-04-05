using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class PlayerAttack : MonoBehaviour
{
    public LookingDetection lookDetection;
    public Weapon currentWeapon;
    public Transform target;
    public ParticleSystem slashEffect;
    public GameObject weapon;
    Cinemachine.CinemachineImpulseSource source;
    public float attackDistanceOffset;
    public bool isAttacking;
    public int damage;
    PlayerRotation PR;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        anim = GetComponent<Animator>();
        PR = GetComponent<PlayerRotation>();
        UpdateCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //play animation
            //disable player rotation so the player can instantly lock onto enemy
            //set a boolean called isAttacking to true

            if (attackCoroutine != null)
                StopCoroutine(Attack());
            StartCoroutine(Attack()); 
    
            //find object where player is looking towards
            //move to closest slowly
            //rotate towards the object
            target = lookDetection.Check(new Ray(transform.position, Camera.main.transform.forward));

            if (target) {
                //MOVES AND LOOKS TO TARGET SLOWLY
                Vector3 dirToEnemy = (transform.position - target.position).normalized;
                Vector3 newPos = target.position + (dirToEnemy * attackDistanceOffset);
                transform.DOMove(newPos, 0.2f);
                //transform.DORotate(dirToEnemy, 1f);
                transform.LookAt(target);
            }  
        }
    }

    Coroutine attackCoroutine;
    public IEnumerator Attack()
    {
        anim.SetTrigger("attack");
        PR.canRotate = false;
        isAttacking = true;
        yield return new WaitForSeconds(2f);
        PR.canRotate = true;
        isAttacking = false;
    }

    //CALLED DURING ANIMATION EVENT TO PLAY PARTICLE, AND OPEN COLLIDER
    //COLLIDER IS CLOSED AFTER A DURATION IN WEAPON
    public void Hit(int damage)
    {
        slashEffect.Play();
        currentWeapon.damage = damage;
        currentWeapon.Enable();
    }

    void UpdateCurrentWeapon()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }
}
