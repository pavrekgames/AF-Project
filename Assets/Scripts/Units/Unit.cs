using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected List<UnitAttribute> attributes = new List<UnitAttribute>();
        [SerializeField] protected int health;
        [SerializeField] protected int armor;
        [SerializeField] protected int attackInterval;
        [SerializeField] protected int attackDamage;
        [SerializeField] protected int optionalAttackDamage;

    }
}
