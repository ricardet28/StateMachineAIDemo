﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject {

    public float moveChaserSpeed = 4f;
    public float movePatrolSpeed = 3f;
    public float lookRange = 40f;
    public float lookSphereCastRadius = 1f;

    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 2f;
    public int attackDamage = 50;

    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;

    public float shootRatio = 1f;
    public float speedRotation = 5f;
}
