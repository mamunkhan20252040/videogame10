using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemy : MonoBehaviour
{
    public EnemyHand enemyHand;

    public int enemyDamage;

    private void Start()
    {
        enemyHand.damage = enemyDamage;
    }
}
