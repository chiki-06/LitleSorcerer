using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] spells1;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim =  GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0.3f;

        spells1[FindSpell1()].transform.position = firePoint.position;
        spells1[FindSpell1()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }


    private int FindSpell1()
    {
        for (int i = 0; i < spells1.Length; i++)
        {
            if (!spells1[i].activeInHierarchy)
                return i;
        }

        return 0; 
    }
     

}
