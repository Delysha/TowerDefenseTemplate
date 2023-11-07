using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ShooterMovement: MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform ShooterRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefabe;
    [SerializeField] private Transform firingPoint;


    [Header("Attribute")]
    [SerializeField] private float targetRange = 1f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float BulletPerSecond = 1f;


    private Transform target;
    private float timeUntilFire;
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateToTarget();

       if (!CheckTargetInRange())
        {
            target = null;
        } else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / BulletPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }


    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefabe, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) < targetRange;
    }

    private void RotateToTarget()
    {
        float angle =  Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x ) * Mathf.Rad2Deg -90;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));

        ShooterRotationPoint.rotation = Quaternion.RotateTowards(ShooterRotationPoint.rotation,targetRotation, rotationSpeed * Time.deltaTime);
    }


}
 