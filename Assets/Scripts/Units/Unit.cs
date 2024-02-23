using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace AFSInterview.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected GameObject unitPresenter;
        [SerializeField] protected List<UnitAttribute> attributes = new List<UnitAttribute>();
        [SerializeField] protected int health;
        [SerializeField] protected int armor;
        [SerializeField] protected int attackInterval;
        [SerializeField] protected int attackDamage;
        [SerializeField] protected int optionalAttackDamage;

        public GameObject UnitPresenter => unitPresenter;

        public int AttackInterwval => attackInterval;

        public virtual void Attack(Unit unit)
        {
            unit.ReceiveDamage(attackDamage);
        }

        public void ReceiveDamage(int damage)
        {
            int damagePoint = damage - armor;

            if (damagePoint < 1)
            {
                damagePoint = 1;
            }

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

        public List<UnitAttribute> GetAttributes()
        {
            return attributes;
        }

    }
}
