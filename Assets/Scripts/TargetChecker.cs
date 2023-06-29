using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    [HideInInspector] public Transform CurrentTarget;
    [SerializeField] private float radiusChecker;
    [SerializeField] private LayerMask layerMask;
    
    private void Update()
    {
        if (CurrentTarget == null)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, radiusChecker, layerMask);
            if (enemies.Length != 0)
            {
                CurrentTarget = enemies[0].gameObject.transform;
            }
        }   
    }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position, radiusChecker);
    // }
}
