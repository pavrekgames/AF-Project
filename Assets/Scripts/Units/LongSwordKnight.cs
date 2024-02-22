using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class LongSwordKnight : Unit
    {
        [SerializeField] private UnitAttribute damagleAttribute;

        public override void Attack(Unit unit, int damage)
        {
            List<UnitAttribute> attributes = unit.GetAttributes();

            if (attributes.Contains(damagleAttribute)){
                damage += optionalAttackDamage;
                unit.ReceiveDamage(damage);
            }
            else
            {
                unit.ReceiveDamage(damage);
            }
        }

    }
}
