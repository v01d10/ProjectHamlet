using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy configuration", menuName = "Scriptable object/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{
    public int Health = 100;
    public float AttackDelay = 1f;
    public int Damage = 5;
    public float AttackRadius = 1.5f;

    public float AIUpdateInterval = 0.1f;

    public float Acceleration = 8;
    public float AngularSpeed = 120;
    //-1 means everything
    public int AreaMask = -1;
    public int AvoidancePriority = 50;
    public float BaseOffset = 0;
    public float Height = 2f;
    public ObstacleAvoidanceType ObstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float Radius = 0.5f;
    public float Speed = 3f;
    public float StoppingDistance = 0.5f;

}
