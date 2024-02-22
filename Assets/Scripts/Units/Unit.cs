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


        protected virtual void Attack(int damage)
        {

        }

        public void ReceiveDamage(int damage)
        {
            int damagePoint = damage - armor;
            health -= damagePoint;
            CheckUnitDead();
        }

        protected virtual void CheckUnitDead()
        {
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
