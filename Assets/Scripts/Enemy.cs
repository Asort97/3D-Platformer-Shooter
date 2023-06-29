using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerGun;
    private float health = 100;
    private float shootInterval;
    private float shootDelay = 0.8f;
    private TargetChecker targetChecker;

    private void Start()
    {
        targetChecker = GetComponent<TargetChecker>();
    }
    private void Update()
    {
        LookAtTarget();
        if(targetChecker.CurrentTarget)
        {
            Shooting();
        }
    }
    private void LookAtTarget()
    {
        if(targetChecker.CurrentTarget != null)
        {
            playerGun.LookAt(targetChecker.CurrentTarget);
        }
        else
        {
            playerGun.eulerAngles = new Vector3(0f, -90f, 0f);
        }        
    }
    private void Shooting()
    {
        if (shootInterval <= 0f)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            shootInterval = shootDelay;
        }

        if (shootInterval >= 0f)
        {
            shootInterval -= Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
