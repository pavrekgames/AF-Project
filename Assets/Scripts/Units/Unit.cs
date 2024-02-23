using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

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

        public delegate void UnitDelegate(Unit unit);
        public static event UnitDelegate OnUnitDead;

        public virtual void Attack(Unit unit)
        {
            Debug.Log(this.name + " Attacks " + unit.name + " with damage ");
            unit.ReceiveDamage(attackDamage);
        }

        public void ReceiveDamage(int damage)
        {
            int damagePoint = damage - armor;

            if (damagePoint < 1)
            {
                damagePoint = 1;
            }

            Debug.Log(damagePoint);
            health -= damagePoint;
            CheckUnitDead();
        }

        protected virtual void CheckUnitDead()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
                OnUnitDead?.Invoke(this);
            }
        }

        public List<UnitAttribute> GetAttributes()
        {
            return attributes;
        }

    }
}
