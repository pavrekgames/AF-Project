using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class Druid : Unit
    {
        [SerializeField] private UnitAttribute damagleAttribute;

        public override void Attack(Unit unit)
        {
            List<UnitAttribute> attributes = unit.GetAttributes();

            if (attributes.Contains(damagleAttribute))
            {
                int finalDamage = attackDamage;
                finalDamage += optionalAttackDamage;
                unit.ReceiveDamage(finalDamage);
            }
            else
            {
                unit.ReceiveDamage(attackDamage);
            }
        }

    }
}
