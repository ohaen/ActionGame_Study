using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int MaxHP { get; set; }
    public int currentHP { get; set; }
    public float moveSpeed { get; set; }
    public int damage { get; set; }
    public float attackCoolTime { get; set; }

    private float _diatance;

    public Transform target;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _diatance = Vector3.Distance(target.position, transform.position);
        
        Debug.Log(Random.Range(0, 2));

        if (_diatance > 3)
        {
            _agent.SetDestination(target.position);
        }
        else
        {
            _agent.SetDestination(transform.position);
        }
    }

    public virtual void LookAtTarget()
    {
        transform.LookAt(target);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        Debug.Log("аж╠щ");
    }
}
