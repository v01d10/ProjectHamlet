using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : PoolableObject
{
    [SerializeField]private ProgressBar HealthBar;
    [SerializeField]private AttackRadius AttackRadius;
    public EnemyMovement Movement;
    public NavMeshAgent Agent;
    public EnemyScriptableObject EnemyScriptableObject;

    private float MaxHealth;
    [SerializeField]private float CurHealth = 100f;


    private const string ATTACK_TRIGGER = "Attack";

    private void Awake()
    {
        AttackRadius.OnAttack += OnAttack;
    }

    public virtual void OnEnable()
    {

        SetupAgentFromConfiguration();
    }

    public override void OnDisable()
    {
        base.OnDisable();

        Agent.enabled = false;
    }

    public virtual void SetupAgentFromConfiguration()
    {
        Agent.acceleration = EnemyScriptableObject.Acceleration;
        Agent.angularSpeed = EnemyScriptableObject.AngularSpeed;
        Agent.areaMask = EnemyScriptableObject.AreaMask;
        Agent.avoidancePriority = EnemyScriptableObject.AvoidancePriority;
        Agent.baseOffset = EnemyScriptableObject.BaseOffset;
        Agent.height = EnemyScriptableObject.Height;
        Agent.obstacleAvoidanceType = EnemyScriptableObject.ObstacleAvoidanceType;
        Agent.radius = EnemyScriptableObject.Radius;
        Agent.speed = EnemyScriptableObject.Speed;
        Agent.stoppingDistance = EnemyScriptableObject.StoppingDistance;

        Movement.UpdateSpeed = EnemyScriptableObject.AIUpdateInterval;

        CurHealth = EnemyScriptableObject.Health;

        AttackRadius.Collider.radius = EnemyScriptableObject.AttackRadius;
        AttackRadius.AttackDelay = EnemyScriptableObject.AttackDelay;
        AttackRadius.Damage = EnemyScriptableObject.Damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            TakeDamage(GunScriptableObject.GunDamage);
            
        }
    }

    private void OnAttack(IDamageable Target)
    {

    }

    public void TakeDamage(float Damage)
    {
        CurHealth -= Damage;
        Debug.Log(CurHealth);

        if(CurHealth <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }

    public void OnDead(Enemy enemy)
    {
        Destroy(HealthBar.gameObject);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetupHealthBar(Canvas Canvas, Camera Camera)
    {
        HealthBar.transform.SetParent(Canvas.transform);
        if(HealthBar.TryGetComponent<FaceCamera>(out FaceCamera faceCamera))
        {
            faceCamera.Camera = Camera;
        }
    }
}
