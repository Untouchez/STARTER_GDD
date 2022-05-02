using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("References")]
    public Quest quest;
    public Material weaponMat;
    public Weapon currentWeapon;
    public bool inCutscene;
    public AudioSource masterSound;
    public AudioClip swordHit1;
    public AudioClip jump;
    
    [Header("Movement Stats")]
    public float jumpHeight;
    public float gravity;
    public float stepDown;
    public float airControl;
    public float jumpDamp;
    public float groundSpeed;
    public float pushPower;
    public float turnSpeed;
    public Vector2 rawInput;
    public bool isJumping;
    public int health = 100;
    public bool canAim;
    public bool isRolling;
    public float rollDistance;
    [SerializeField] private float inputAccel, inputDeccel;

    [Header("Attack Stats")]
    public float anticipationSpeed;
    public float recoverySpeed;
    public float attackSpeed;
    public bool isAttacking;
    public bool canAttack = true;
    public bool block;
    [Space(10)]

    public Color glowColor;
    public float glowIntensity;

    Camera mainCamera;
    Vector2 input;
    Vector3 rootMotion;
    Vector3 velocity;
    Blink blink;
    Animator anim;
    CharacterController CC;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
        blink = GetComponent<Blink>();
        weaponMat.EnableKeyword("_EMISSION");
        mainCamera = Camera.main;
        swordHit1 = (AudioClip)Resources.Load("sword-first-hit");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRolling||inCutscene)
            return;
        HandleInputs();
        HandleMovement();
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    private void FixedUpdate()
    {
        FaceCameraForward();
        if (isJumping)
            UpdateInAir();
        else
            UpdateOnGround();
    }

    private void OnAnimatorMove()
    {
        if (isRolling)
            rootMotion += rollDistance*anim.deltaPosition;
        else 
            rootMotion += anim.deltaPosition;
    }

    void HandleInputs()
    {
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        if (rawInput.x != 0)
            input.x = Mathf.MoveTowards(input.x, rawInput.x, inputAccel * Time.deltaTime);
        else
            input.x = Mathf.MoveTowards(input.x, 0, inputDeccel * Time.deltaTime);

        if (rawInput.y != 0)
            input.y = Mathf.MoveTowards(input.y, rawInput.y, inputAccel * Time.deltaTime);
        else
            input.y = Mathf.MoveTowards(input.y, 0, inputDeccel * Time.deltaTime);

        anim.SetBool("sprint", Input.GetKey(KeyCode.LeftShift));

        anim.SetFloat("InputX", input.x);
        anim.SetFloat("InputY", input.y);
    }

    #region Movement
    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl) && rawInput != Vector2.zero && !isJumping)
            Dodge();
    }

    public void Dodge()
    {
        anim.SetTrigger("dodge");
        StartCoroutine(RollCheck());
    }

    public IEnumerator RollCheck()
    {
        isRolling = true;
        //yield return new WaitForSeconds(0.1f); // for transition
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && anim.GetCurrentAnimatorStateInfo(0).IsName("Dodge"));
        isRolling = false;
    }

    void Jump()
    {
        if (!isJumping)
        {

            anim.SetTrigger("jump");
        }
    }

    private void UpdateOnGround()
    {
        Vector3 stepForwardAmount = rootMotion * groundSpeed;
        Vector3 stepDownAmount = Vector3.down * stepDown;

        CC.Move(stepForwardAmount + stepDownAmount);
        rootMotion = Vector3.zero;

        if (!CC.isGrounded)
        {
            SetInAir(0);
        }
    }

    private void UpdateInAir()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        Vector3 displacement = velocity * Time.fixedDeltaTime;
        displacement += CalculateAirControl();
        CC.Move(displacement);
        isJumping = !CC.isGrounded;
        rootMotion = Vector3.zero;
        anim.SetBool("isJumping", isJumping);
    }

    Vector3 CalculateAirControl()
    {
        return ((transform.forward * input.y) + (transform.right * input.x)) * (airControl / 100);
    }

    private void SetInAir(float jumpVelocity)
    {
        isJumping = true;
        velocity = anim.velocity * jumpDamp * groundSpeed;
        velocity.y = jumpVelocity;
        anim.SetBool("isJumping", true);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
    #endregion

    #region Rotation
    public void FaceCameraForward()
    {
        if (canAim && rawInput != Vector2.zero)
        {
            float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
        }
    }
    #endregion

    #region Attack
    public void Attack()
    {
        if (canAttack)
        {
            anim.SetTrigger("attack");
            canAttack = false;
            StartCoroutine(IsAttackingCheck());
        }
        return;
        //if (isAttacking)
        //{
        //    if (canGoldLink && !missedGoldLink)
        //    { // GOLD LINK
        //        //blink.BlinkME(goldLinkDuration, goldLinkIntensity, Color.green);
        //        anim.SetTrigger("gold_attack");
        //    }
        //    else
        //    { // MISSED GOLD LINK ATTACK 
        //        //if (!missedGoldLink)
        //            //blink.BlinkME(goldLinkDuration, goldLinkIntensity, Color.red);
        //        anim.SetTrigger("attack");
        //        missedGoldLink = true;
        //    }
        //}
        //else
        //{ // FIRST ATTACK
        //    anim.SetTrigger("attack");
        //}
        //StartCoroutine(IsAttackingCheck());
    }

    //WHEN ATTACKING IS DONE 
    public IEnumerator IsAttackingCheck()
    {
        isAttacking = true;
        masterSound.clip = swordHit1;
        masterSound.Play();
        yield return new WaitForSeconds(0.1f); // for transition
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        anim.ResetTrigger("gold_attack");
        anim.ResetTrigger("attack");
        canAttack = true;
        isAttacking = false;
        anim.speed = 1f;
        currentWeapon.hitBox.enabled = false;
    }
    #endregion

    #region AnimationEvents
    public void Anticipation()
    {
        GlowWeapon(glowIntensity, glowColor);
        anim.speed = anticipationSpeed;
    }

    public void Anticipation_(float speed)
    {
        GlowWeapon(glowIntensity, glowColor);
        anim.speed = speed;
    }

    public void OpenColliders()
    {
        currentWeapon.hitBox.enabled = true;
        GlowWeapon(0f, glowColor);
        anim.speed = attackSpeed;
    }

    public void CloseColliders()
    {
        canAttack = true;
        currentWeapon.hitBox.enabled = false;
        anim.speed = recoverySpeed;
        //blink.BlinkME(goldLinkDuration, goldLinkIntensity, goldLinkColor);
        StartCoroutine(Recover());
    }


    public IEnumerator Recover()
    {
        yield return new WaitForSeconds(0.2f);
        GlowWeapon(0f, glowColor);
        anim.speed = 1f;
    }

    public void Hit()
    {

    }

    public void JumpEvent()
    {
        float jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);
        SetInAir(jumpVelocity);
    }
    #endregion

    //helper
    public void GlowWeapon(float intensity, Color color)
    {
        weaponMat.SetColor("_EmissionColor", color * intensity);
        currentWeapon.weaponLight.color = color;
        currentWeapon.weaponLight.enabled = (intensity != 0);
    }   
}
