using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform target;
    [SerializeField] private Transform playerGun;
    [SerializeField] private float shootDelay;
    [SerializeField] private float speedMovement;
    [SerializeField] private float forceJump;    
    private float shootInterval;
    private GroundChecker groundChecker;
    private TargetChecker targetChecker;
    private UIManager uiManager;
    private Rigidbody rb;
    private ButtonPointer shootButton;

    private void Start()
    {
        uiManager = UIManager.Instance;

        groundChecker = GetComponentInChildren<GroundChecker>();
        targetChecker = GetComponent<TargetChecker>();
        rb = GetComponent<Rigidbody>();

        InitUI();
    }
    private void InitUI()
    {
        uiManager.JumpBtn.onClick.AddListener(Jump);
        shootButton = uiManager.ShootBtn;
    }
    private void Update()
    {
        LookAtTarget();
        Shooting();
        Move(); 
    }
    private void Move()
    {
        if (moveJoystick.Horizontal != 0f)
        {
            Vector2 pos = new Vector3(moveJoystick.Horizontal, 0f);
            transform.Translate(pos * Time.deltaTime * speedMovement);  

            if(!targetChecker.CurrentTarget)
            {
                if (moveJoystick.Horizontal > 0f)
                {
                    playerBody.eulerAngles = new Vector2(0f, 0f);
                }
                if (moveJoystick.Horizontal < 0f)
                {
                    playerBody.eulerAngles = new Vector2(0f, 180f);
                }                
            }
        }   
    }
    private void LookAtTarget()
    {
        if(targetChecker.CurrentTarget != null)
        {
            playerGun.LookAt(targetChecker.CurrentTarget);
        }
        // else
        // {
        //     playerGun.eulerAngles = new Vector3(0f, 90f, 0f);
        // }        
    }
    private void Shooting()
    {
        if (shootButton.IsPressed)
        {
            if (shootInterval <= 0f)
            {
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                shootInterval = shootDelay;
            }
        }

        if (shootInterval >= 0f)
        {
            shootInterval -= Time.deltaTime;
        }
    }
    private void Jump()
    {
        if  (groundChecker.IsGrounded)
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }    
    public void TakeDamage(float damage)
    {
        Debug.Log($"Taking Damage - " + damage);
    }
}
