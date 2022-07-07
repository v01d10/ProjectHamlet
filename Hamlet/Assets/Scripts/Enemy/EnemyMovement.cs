using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float UpdateSpeed = 0.1f;
    private NavMeshAgent Agent;

    public EnemyState DefaultState;
    private EnemyState _state;
    public EnemyState State
    {
        get
        {
            return _state;
        }
        set
        {
            OnStateChange?.Invoke(_state, value);
            _state = value;
        }
    }

    public delegate void StateChangeEvent(EnemyState oldState, EnemyState newState);
    public StateChangeEvent OnStateChange;
    public float IdleLocationRadius = 4f;
    public float IdleMovespeedMultiplier = 0.5f;

    private Coroutine FollowCoroutine;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        OnStateChange += HandleStateChange;
    }

    private void OnDisable()
    {
        _state = DefaultState;
    }

    public void Spawn()
    {
        OnStateChange?.Invoke(EnemyState.Spawn, DefaultState);
    }

    private void HandleStateChange(EnemyState oldState, EnemyState newState)
    {
        if(oldState != newState)
        {
            if(FollowCoroutine != null)
            {
                StopCoroutine(FollowCoroutine);
            }

            if(oldState == EnemyState.Idle)
            {
                Agent.speed /= IdleMovespeedMultiplier;
            }

            switch(newState)
            {
                case EnemyState.Idle:
                    FollowCoroutine = StartCoroutine(DoIdleMotion());
                    break;
                case EnemyState.Patrol:

                    break;
                case EnemyState.Chase:
                    FollowCoroutine = StartCoroutine(FollowTarget());
                    break;
            }
        }
    }

    private IEnumerator DoIdleMotion()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        Agent.speed *= IdleMovespeedMultiplier;

        while(true)
        {
            if (!Agent.enabled || !Agent.isOnNavMesh)
            {
                yield return Wait;
            }
            else if (Agent.remainingDistance <= Agent.stoppingDistance)
            {
                Vector2 point = Random.insideUnitCircle * IdleLocationRadius;
                NavMeshHit hit;

                if(NavMesh.SamplePosition(Agent.transform.position + new Vector3(point.x,0,point.y), out hit, 2f, Agent.areaMask))
                {
                    Agent.SetDestination(hit.position);
                }
            }

            yield return Wait;
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while(enabled)
        {
            Agent.SetDestination(Player.transform.position);

            yield return Wait;
        }
    }
}
